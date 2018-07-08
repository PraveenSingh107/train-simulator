using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessObjects
{
    public class Train
    {
        private Object _lock = new object();

        private int _trainId;
        public int TrainId
        {
            get { return _trainId; }
            set { _trainId = value; }
        }

        private string _trainName;
        public string TrainName
        {
            get { return _trainName; }
            set { _trainName = value; }
        }

        private int _shipmentCapacity;
        public int ShipmentCapacity
        {
            get { return _shipmentCapacity; }
            set { _shipmentCapacity = value; }
        }

        private int _runningShipmentCount;
        public int RunningShipmentCount
        {
            get { return _runningShipmentCount; }
            set { _runningShipmentCount = value; }
        }

        private int _speedfactor;
        public int SpeedFactor
        {
            get { return _speedfactor; }
            set { _speedfactor = value; }
        }

        private volatile TrainRunningStatus _currentRunningStatus;
        public TrainRunningStatus CurrentRunningStatus
        {
            get { return _currentRunningStatus; }
            set { _currentRunningStatus = value; }
        }
        
        private Dictionary<int, Stack<Shipment>> _dicLoadedShipment = new Dictionary<int,Stack<Shipment>>();

        public Train(int trainId, String trainName, int shipmentCapacity, int speed)
        {
            _trainId = trainId;
            _trainName = trainName;
            _shipmentCapacity = shipmentCapacity;
            ConvertToLogicalSpeedFactor(speed);
        }

        private void ConvertToLogicalSpeedFactor(int speed)
        {
            if (speed <= 50)
                _speedfactor = 1;
            else if(speed <= 100)
                _speedfactor = 2;
            else if (speed <= 150)
                _speedfactor = 2;
            else if (speed <= 200)
                _speedfactor = 3;
            else if (speed <= 250)
                _speedfactor = 4;
            else
                _speedfactor = 5;

        }

        public bool IsAnyShipmentForStation(int stationId)
        {
            if (_dicLoadedShipment.ContainsKey(stationId))
            {
                var stack = _dicLoadedShipment[stationId];
                if (stack.Count() > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Shipment UnloadShipment(int stationId)
        {
            if (_dicLoadedShipment.ContainsKey(stationId))
            {
                lock (_lock)
                {
                    _runningShipmentCount--;
                    if (_dicLoadedShipment[stationId].Count() > 0)
                    {
                        return _dicLoadedShipment[stationId].Pop();
                    }
                    else
                        _dicLoadedShipment.Remove(stationId);
                }
            }
            throw new Exception("No shipment to deliver.");
        }

        public bool IsShipmentCapacityFull()
        {
            if (_shipmentCapacity - _runningShipmentCount > 0)
                return false;
            else
                return true;
        }

        public void LoadShipment(Shipment shipment)
        {
            lock (_lock)
            {
                if (_dicLoadedShipment.ContainsKey(shipment.DestinationStation.StationId))
                {
                    _dicLoadedShipment[shipment.DestinationStation.StationId].Push(shipment);
                }
                else
                {
                    Stack<Shipment> stackShipment = new Stack<Shipment>();
                    stackShipment.Push(shipment);
                    _dicLoadedShipment.Add(shipment.DestinationStation.StationId, stackShipment);
                }
                _runningShipmentCount++;
            }
        }

        public override string ToString()
        {
            return _trainName + ", Speed = " + _speedfactor;
        }

        public override bool Equals(object obj)
        {
            var train = obj as Train;
            return this._trainId.Equals(train.TrainId);
        }

        public override int GetHashCode()
        {
            return _trainId;
        }
    }
}
