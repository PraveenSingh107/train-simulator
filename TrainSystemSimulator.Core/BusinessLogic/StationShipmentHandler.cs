using BlueStacks.Core.BusinessObjects;
using BlueStacks.Core.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessLogic
{
    public sealed class StationShipmentHandler 
    {

        private Queue<Shipment> _queueShipment;
        private AutoResetEvent _queueShipmentSynchronizer = new AutoResetEvent(false);
        private Thread _queueProcessingThread;
        private readonly static StationShipmentHandler _instance = new StationShipmentHandler();
        public static EventHandler<StationShipmentEventArgs> ShipmentQueuedAtStation;
        public static EventHandler<StationShipmentEventArgs> ShipmentDequeuedFromStation;

        private StationShipmentHandler()
        {
            _queueShipment = new Queue<Shipment>();
            _queueProcessingThread = new Thread(ProcessQueuedShipment);
            GlobalClock.StationShipmentArrived += QueueArrivedShipment;
            _queueProcessingThread.IsBackground = true;
        }

        public void Start()
        {
            _queueProcessingThread.Start();
        }


        public static StationShipmentHandler GetInstance()
        {
            return _instance;
        }

        public void ProcessQueuedShipment()
        {
            try
            {
                if (_queueShipment.Count() > 0)
                {
                    while (_queueShipment.Count() > 0)
                    {
                        Shipment shipment = _queueShipment.Dequeue();
                        var station = LookupCache.GetInstance().GetStation(shipment.SourceStation.StationId);
                        station.DeliverShipmentToStation(shipment);
                        StationShipmentEventArgs args = new StationShipmentEventArgs(shipment.SourceStation.StationId,shipment.DestinationStation.StationId);
                        args.Message = shipment + " Shipment queued at " + shipment.SourceStation;
                        args.DeliveredShipment = shipment;
                        OnShipmentQueued(this, args);
                    }
                }
                
                _queueShipmentSynchronizer.WaitOne();
                ProcessQueuedShipment();
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void OnShipmentQueued(object sender, StationShipmentEventArgs eventArgs)
        {
            var shipmentQueuedAtStation = ShipmentQueuedAtStation;
            if (shipmentQueuedAtStation != null)
                shipmentQueuedAtStation(sender, eventArgs);
        }

        private void QueueArrivedShipment(object sender, StationShipmentEventArgs eventArgs)
        {
            try 
	        {	        
                Station sourceStation = LookupCache.GetInstance().GetStation(eventArgs.SourceStationNumber);
                Station destinationStation = LookupCache.GetInstance().GetStation(eventArgs.DestinationStationNumber);
		        Shipment shipment = new Shipment(sourceStation,destinationStation);
                _queueShipment.Enqueue(shipment);
                _queueShipmentSynchronizer.Set();
            }
	        catch (Exception)
	        {
		        throw;
	        }
            
        }

        public void CleanUp()
        {
            GlobalClock.StationShipmentArrived -= QueueArrivedShipment;
        }

    }
}
