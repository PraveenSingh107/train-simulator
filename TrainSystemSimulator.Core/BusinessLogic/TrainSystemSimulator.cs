using BlueStacks.Core.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessLogic
{
    public class TrainSystemSimulator
    {

        private static TrainSystemSimulator _instance = new TrainSystemSimulator();

        private Dictionary<Train, TrainCurrentLocation> _dicTrainCurrentLocations = new Dictionary<Train, TrainCurrentLocation>();
        private List<TrainCurrentLocation> _lstOfTrainsForLoading = new List<TrainCurrentLocation>();
        private List<TrainCurrentLocation> _lstOfTrainsForUnloading = new List<TrainCurrentLocation>();
        private List<TrainCurrentLocation> _lstTrainsToStart = new List<TrainCurrentLocation>();
        public static EventHandler<TrainProcessEventArgs> TrainOtherEvent;
        public static EventHandler<TrainProcessEventArgs> TrainProgressEvent;
        public static EventHandler<TrainProcessEventArgs> TrainShipmentLoadEvent;
        public static EventHandler<TrainProcessEventArgs> TrainShipmentUnloadEvent;
        public static EventHandler<TrainProcessEventArgs> TrainArrivedAtStationEvent;

        Thread loadingUnloadingThread;
        private AutoResetEvent _signalEvent = new AutoResetEvent(false);
        private static Object _lock = new object();

        private TrainSystemSimulator()
        {
            GlobalClock.GlobalClockTimeChanged += GlobalClock_GlobalClockTimeChanged;
            loadingUnloadingThread = new Thread(ProcessShipmentAtStation);
            loadingUnloadingThread.IsBackground = true;
            loadingUnloadingThread.Start();
        }

        public static TrainSystemSimulator GetInstance()
        {
            return _instance;
        }

        public void Start()
        {
            Random randomStationNumberGenerator = new Random();
            
            // Start trains at random stations
            foreach (var train in LookupCache.GetInstance().GetTrains())
            {
                int stationId = randomStationNumberGenerator.Next(1, LookupCache.GetInstance().StationCount() + 1);
                TrainTrack trainTrack = LookupCache.GetInstance().GetNextTrack(stationId);
                TrainCurrentLocation trainCurrentLocation = new TrainCurrentLocation();
                trainCurrentLocation.Train = train;
                trainCurrentLocation.Track = trainTrack;
                trainCurrentLocation.DistanceLeft = trainCurrentLocation.Track.TrackLength;
                trainCurrentLocation.Train.CurrentRunningStatus = TrainRunningStatus.Waiting;
                _lstTrainsToStart.Add(trainCurrentLocation);
            }

        }

        public void GlobalClock_GlobalClockTimeChanged(object sender, EventArgs e)
        {
            _signalEvent.Set();
        }

        public void OnTrainProgressed(object sender, TrainProcessEventArgs args)
        {
            var trainProgressEvent = TrainProgressEvent;
            if (trainProgressEvent != null)
                trainProgressEvent(sender, args);
        }

        public void OnTrainOtherEvent(object sender, TrainProcessEventArgs args)
        {
            var trainOtherEvent = TrainOtherEvent;
            if (trainOtherEvent != null)
                trainOtherEvent(sender, args);
        }

        public void OnTrainShipmentLoadEvent(object sender, TrainProcessEventArgs args)
        {
            var trainShipmentLoadEvent = TrainShipmentLoadEvent;
            if (trainShipmentLoadEvent != null)
                trainShipmentLoadEvent(sender, args);
        }

        public void OnTrainShipmentUnloadEvent(object sender, TrainProcessEventArgs args)
        {
            var trainShipmentUnloadEvent = TrainShipmentUnloadEvent;
            if (trainShipmentUnloadEvent != null)
                trainShipmentUnloadEvent(sender, args);
        }

        public void OnTrainArrivedAtStation(object sender, TrainProcessEventArgs args)
        {
            var trainArrivedAtStationEvent = TrainArrivedAtStationEvent;
            if (trainArrivedAtStationEvent != null)
                trainArrivedAtStationEvent(sender, args);
        }
        
        private void ProcessShipmentAtStation()
        {
            _signalEvent.WaitOne();
            
            // Process Running Trains
            List<TrainCurrentLocation> lstToMovetoUnLoadingQueue = new List<TrainCurrentLocation>();
            foreach (var train in _dicTrainCurrentLocations.Keys)
            {
                var trainCurrentLocation = _dicTrainCurrentLocations[train];
                if (train.CurrentRunningStatus == TrainRunningStatus.Running && trainCurrentLocation.DistanceLeft <= 0)
                {
                    lstToMovetoUnLoadingQueue.Add(trainCurrentLocation);
                }
                else if (train.CurrentRunningStatus == TrainRunningStatus.Running)
                {
                    trainCurrentLocation.DistanceLeft -= train.SpeedFactor;
                    if (trainCurrentLocation.DistanceLeft <= 0)
                    {
                        trainCurrentLocation.DistanceLeft = 0; 
                    }
                    else
                    {
                        TrainProcessEventArgs args = new TrainProcessEventArgs();
                        args.Message = trainCurrentLocation.Train +" has to travel distance : "+trainCurrentLocation.DistanceLeft;
                        args.TrainId = trainCurrentLocation.Train.ToString();
                        args.TrackId = trainCurrentLocation.Track.ToString();
                        OnTrainProgressed(this, args);
                    }
                }
            }

            List<TrainCurrentLocation> lstToAddToLoadingTrainsQueue = new List<TrainCurrentLocation>();
            // Unloading shipment 
            foreach (var trainCurrentLocation in _lstOfTrainsForUnloading)
            {
                if (trainCurrentLocation.Train.IsAnyShipmentForStation(trainCurrentLocation.Track.DestinationStationId))
                {
                    var shipment = trainCurrentLocation.Train.UnloadShipment(trainCurrentLocation.Track.DestinationStationId);
                    TrainProcessEventArgs args = new TrainProcessEventArgs();
                    args.Message = "<<" + shipment + " shipment unloaded at " + shipment.DestinationStation;
                    args.TrainId = trainCurrentLocation.Train.ToString();
                    args.TrackId = trainCurrentLocation.Track.ToString();
                    args.DeliveredShipment = shipment;
                    OnTrainShipmentUnloadEvent(this, args);
                }
                else
                {
                    trainCurrentLocation.Train.CurrentRunningStatus = TrainRunningStatus.LoadingShipment;
                    TrainProcessEventArgs args = new TrainProcessEventArgs();
                    args.Message = "There is no shipment to unload at Station"+ trainCurrentLocation.Track.DestinationStationId;
                    args.TrainId = trainCurrentLocation.Train.ToString();
                    args.TrackId = trainCurrentLocation.Track.ToString();
                    OnTrainOtherEvent(this, args);
                    lstToAddToLoadingTrainsQueue.Add(trainCurrentLocation);
                }
            }

            List<TrainCurrentLocation> lstToAddToWaitingTrainsQueue = new List<TrainCurrentLocation>();
            // loading shipment
            foreach (var trainCurrentLocation in _lstOfTrainsForLoading)
            {
                Station station = LookupCache.GetInstance().GetStation(trainCurrentLocation.Track.DestinationStationId);
                if (!station.IsStationShipmentEmpty() && !trainCurrentLocation.Train.IsShipmentCapacityFull())
                {
                    Shipment shipment = station.DeliverShipmentToTrain();
                    trainCurrentLocation.Train.LoadShipment(shipment);
                    TrainProcessEventArgs args = new TrainProcessEventArgs();
                    args.Message = ">> " + shipment + " loaded from " + shipment.DestinationStation;
                    args.TrainId = trainCurrentLocation.Train.ToString();
                    args.TrackId = trainCurrentLocation.Track.ToString();
                    args.DeliveredShipment = shipment;
                    OnTrainShipmentLoadEvent(this, args);
                }
                else if (station.IsStationShipmentEmpty())
                {
                    TrainProcessEventArgs args = new TrainProcessEventArgs();
                    args.Message = station + " has no items to load into train";
                    args.TrainId = trainCurrentLocation.Train.ToString();
                    args.TrackId = trainCurrentLocation.Track.ToString();
                    OnTrainOtherEvent(this, args);
                    lstToAddToWaitingTrainsQueue.Add(trainCurrentLocation);
                    trainCurrentLocation.Train.CurrentRunningStatus = TrainRunningStatus.Stopped;
                }
                else if (trainCurrentLocation.Train.IsShipmentCapacityFull())
                {
                    TrainProcessEventArgs args = new TrainProcessEventArgs();
                    args.Message = "Train shipment capacity is full now.";
                    args.TrainId = trainCurrentLocation.Train.ToString();
                    args.TrackId = trainCurrentLocation.Track.ToString();
                    OnTrainOtherEvent(this, args);
                    lstToAddToWaitingTrainsQueue.Add(trainCurrentLocation);
                    trainCurrentLocation.Train.CurrentRunningStatus = TrainRunningStatus.Stopped;
                }
            }

            List<TrainCurrentLocation> _listToRemoveFromWaiting = new List<TrainCurrentLocation>();
            // check track token to start.
            foreach (var trainCurrentLocation in _lstTrainsToStart)
            {
                if(trainCurrentLocation.Train.CurrentRunningStatus == TrainRunningStatus.Stopped)
                {
                    var track = LookupCache.GetInstance().GetNextTrack(trainCurrentLocation.Track.DestinationStationId);
                    trainCurrentLocation.Track = track;
                    trainCurrentLocation.DistanceLeft = trainCurrentLocation.Track.TrackLength;
                    trainCurrentLocation.Train.CurrentRunningStatus = TrainRunningStatus.Waiting;
                }
                if (trainCurrentLocation.Train.CurrentRunningStatus == TrainRunningStatus.Waiting)
                {
                    if (TrackTokenController.GetInstance().CheckTrackTokenAvailability(trainCurrentLocation.Track.SourceStationId, trainCurrentLocation.Track.DestinationStationId))
                    {
                        TrackTokenController.GetInstance().AcquireTrackToken(trainCurrentLocation.Track.SourceStationId, trainCurrentLocation.Track.DestinationStationId,
                            trainCurrentLocation.Train.TrainId);
                        trainCurrentLocation.Train.CurrentRunningStatus = TrainRunningStatus.Running;
                        _dicTrainCurrentLocations.Add(trainCurrentLocation.Train, trainCurrentLocation);
                        
                        TrainProcessEventArgs args = new TrainProcessEventArgs();
                        args.Message = "Train departured from Station" + trainCurrentLocation.Track.SourceStationId;
                        args.TrainId = trainCurrentLocation.Train.ToString();
                        args.TrackId = trainCurrentLocation.Track.ToString();
                        OnTrainOtherEvent(this, args);
                        _listToRemoveFromWaiting.Add(trainCurrentLocation);
                    }
                    else
                    {
                        TrainProcessEventArgs args = new TrainProcessEventArgs();
                        args.Message = "Train waiting for track " + trainCurrentLocation.Track  + " to be free."; 
                        args.TrainId = trainCurrentLocation.Train.ToString();
                        args.TrackId = trainCurrentLocation.Track.ToString();
                        OnTrainOtherEvent(this, args);
                    }
                }
            }

            // Remove from waiting list.
            foreach (var train in _listToRemoveFromWaiting)
            {
                if (_lstTrainsToStart.Contains(train)) 
                    _lstTrainsToStart.Remove(train);
            }

            // Move from running to unloading
            foreach(var trainCurrentLocation in lstToMovetoUnLoadingQueue)
            {
                if (_dicTrainCurrentLocations.ContainsKey(trainCurrentLocation.Train))
                {
                    TrackTokenController.GetInstance().ReleaseTrackToken(trainCurrentLocation.Track.SourceStationId, trainCurrentLocation.Track.DestinationStationId);
                    _dicTrainCurrentLocations.Remove(trainCurrentLocation.Train);
                    _lstOfTrainsForUnloading.Add(trainCurrentLocation);
                    TrainProcessEventArgs args = new TrainProcessEventArgs();
                    args.TrainId = trainCurrentLocation.Train.ToString();
                    args.TrackId = trainCurrentLocation.Track.ToString();
                    OnTrainArrivedAtStation(this, args);
                    
                }
            }

            // Move from unloading to loading
            foreach (var trainCurrentLocation in lstToAddToLoadingTrainsQueue)
            {
                if (_lstOfTrainsForUnloading.Contains(trainCurrentLocation))
                {
                    _lstOfTrainsForUnloading.Remove(trainCurrentLocation);
                    _lstOfTrainsForLoading.Add(trainCurrentLocation);
                }
            }

            // Move from loading to waiting
            foreach (var trainCurrentLocation in lstToAddToWaitingTrainsQueue)
            {
                if (_lstOfTrainsForLoading.Contains(trainCurrentLocation))
                {
                    _lstOfTrainsForLoading.Remove(trainCurrentLocation);
                    _lstTrainsToStart.Add(trainCurrentLocation);
                }
            }
            ProcessShipmentAtStation();
        }

        public void AddTrainCurrentLocation(TrainCurrentLocation trainCurrentLocation)
        {
            _dicTrainCurrentLocations.Add(trainCurrentLocation.Train, trainCurrentLocation); 
        }

        public void CleanUp()
        {
            GlobalClock.GlobalClockTimeChanged -= GlobalClock_GlobalClockTimeChanged;
        }
    }
}
