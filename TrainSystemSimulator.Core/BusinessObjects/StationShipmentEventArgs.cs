using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessObjects
{
    public class StationShipmentEventArgs : EventArgs
    {
        public int SourceStationNumber { get; private set; }
        public int DestinationStationNumber { get; private set; }
        public string Message { get; set; }
        public Shipment DeliveredShipment { get; set; }

        public StationShipmentEventArgs(int stationNumber, int destionationStationNumber)
        {
            SourceStationNumber = stationNumber;
            DestinationStationNumber = destionationStationNumber;
        }
    }

    public class TrainProcessEventArgs : EventArgs
    {
        public string TrainId { get; set; }
        public string Message { get; set; }
        public string TrackId { get; set; }
        public Shipment DeliveredShipment { get; set; }
        public TrainProcessEventArgs()
        {
        }
    }
}
