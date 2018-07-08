using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessObjects
{
    public class TrainTrack
    {
        public int SourceStationId { get; private set; }
        public int DestinationStationId { get; private set; }
        public int TrackLength { get; private set; }
        public string TrackId { get; private set; }

        public TrainTrack(int sourceStationId,int destinationStationId,int length)
        {
            SourceStationId = sourceStationId;
            DestinationStationId = destinationStationId;
            TrackLength = length;
            TrackId = sourceStationId.ToString() + "To" + destinationStationId.ToString();
        }

        public override string ToString()
        {
            return SourceStationId + " To " + DestinationStationId + " , Track Length = " + TrackLength;
        }
    }
}
