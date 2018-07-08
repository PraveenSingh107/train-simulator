using BlueStacks.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessObjects
{
    public class Station
    {

        public static EventHandler<StationShipmentEventArgs> ShipmentDequeuedFromStation;

        private int _stationId;
        public int StationId
        {
            get { return _stationId; }
        }

        private String _stationName;
        public String StationName
        {
            get { return _stationName; }
        }

        private ConcurrentQueue<Shipment> _queStationShipment;

        public Station(int stationId,String stationName)
        {
            _stationId = stationId;
            _stationName = stationName;
            _queStationShipment = new ConcurrentQueue<Shipment>();
        }

        public void DeliverShipmentToStation(Shipment shipmentToBeDelivered)
        {
            try
            {
                _queStationShipment.Enqueue(shipmentToBeDelivered);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Shipment DeliverShipmentToTrain()
        {
            try
            {
                Shipment shipment;
                if (_queStationShipment.TryDequeue(out shipment))
                {
                    if (shipment != null)
                    {
                        StationShipmentEventArgs args = new StationShipmentEventArgs(shipment.SourceStation.StationId, shipment.DestinationStation.StationId);
                        args.Message = shipment + " Shipment queued at " + shipment.SourceStation;
                        args.DeliveredShipment = shipment;
                        OnShipmentDequeued(this, args);
                        return shipment;
                    }
                }
                throw new Exception("Station has not shipment now.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsStationShipmentEmpty()
        {
            try
            {
                return _queStationShipment.IsEmpty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override string ToString()
        {
            return StationName;
        }

        public void OnShipmentDequeued(object sender, StationShipmentEventArgs eventArgs)
        {
            var shipmentDequeuedFromStation = ShipmentDequeuedFromStation;
            if (shipmentDequeuedFromStation != null)
                shipmentDequeuedFromStation(sender, eventArgs);
        }

    }
}
