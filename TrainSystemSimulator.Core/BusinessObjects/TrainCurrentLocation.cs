using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessObjects
{
    public class TrainCurrentLocation
    {
        public Train Train { get; set; }
        public TrainTrack Track { get; set; }
        public int DistanceLeft { get; set; }
    }
}
