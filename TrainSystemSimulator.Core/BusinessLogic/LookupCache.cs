using BlueStacks.Core.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessLogic
{
    public sealed class LookupCache
    {

        private static readonly LookupCache _instance = new LookupCache();
        //private Dictionary<int, int> _dicDestionationStationdistance;
        private Dictionary<int, Station> _dicStations;
        private Dictionary<int, Train> _dicTrains;
        private Dictionary<string, TrainTrack> _dicTrainTracks;

        static LookupCache()
        {
        }

        private LookupCache()
        {
            //_dicDestionationStationdistance = new Dictionary<int, int>();
            _dicStations = new Dictionary<int, Station>();
            _dicTrains = new Dictionary<int, Train>();
        }

        public static LookupCache GetInstance()
        {
            return _instance;
        }

        //public void AddDestinationStaionDistance(int destionationStation, int distance)
        //{
        //    if (_dicDestionationStationdistance.ContainsKey(destionationStation))
        //        _dicDestionationStationdistance[destionationStation] = distance;
        //    else
        //        _dicDestionationStationdistance.Add(destionationStation, distance);
        //}

        //public int GetDestionStationDistance(int destinationStation)
        //{
        //    if (_dicDestionationStationdistance.ContainsKey(destinationStation))
        //        return _dicDestionationStationdistance[destinationStation];
        //    else
        //        throw new Exception("Destionation staion distance is not registered.");
        //}

        public Station GetStation(int stationId)
        {
            try
            {
                if (_dicStations.ContainsKey(stationId))
                    return _dicStations[stationId];
                else
                    throw new Exception("Station not found");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<int,Station> GetStations()
        {
            try
            {
                return _dicStations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int StationCount()
        {
            return _dicStations.Count();
        }

        public void AddStation(Station station)
        {
            try
            {
                _dicStations.Add(station.StationId, station);
            }
            catch (Exception )
            {
                throw;
            }
        }

        public Train GetTrain(int trainId)
        {
            try
            {
                if (_dicTrains.ContainsKey(trainId))
                    return _dicTrains[trainId];
                else
                    throw new Exception("Train not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Train> GetTrains()
        {
            try
            {
                List<Train> lstTrains = new List<Train>();
                foreach (var key in _dicTrains.Keys)
                    lstTrains.Add(_dicTrains[key]);

                return lstTrains;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddTrain(Train train)
        {
            try
            {
                _dicTrains.Add(train.TrainId, train);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddTracks(Dictionary<string, TrainTrack> dicTracks)
        {
            _dicTrainTracks = dicTracks;
        }

        public int GetTrackLength(string trackName)
        {
            if (_dicTrainTracks != null && _dicTrainTracks.ContainsKey(trackName))
                return _dicTrainTracks[trackName].TrackLength;
            else
                throw new Exception("Track not found.");
        }

        public TrainTrack GetNextTrack(int stationId)
        {
            if (_dicTrainTracks != null)
            {
                string searchKey = stationId + "To";
                foreach (var key in _dicTrainTracks.Keys)
                {
                    if (key.Contains(searchKey))
                    {
                        return _dicTrainTracks[key];
                    }
                }
            }
            throw new Exception("StationId not matched.");
        }

        public TrainTrack GetTrack(string trackId)
        {
            if (_dicTrainTracks != null & _dicTrainTracks.ContainsKey(trackId))
                return _dicTrainTracks[trackId];
            throw new Exception(trackId + " track not found.");
        }

        public Dictionary<string,TrainTrack> GetTracks()
        {
            return _dicTrainTracks;
        }

    }
}
