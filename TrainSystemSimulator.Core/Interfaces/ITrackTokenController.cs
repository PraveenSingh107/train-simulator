using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.Interfaces
{
    public interface ITrackTokenController
    {
        bool CheckTrackTokenAvailability(int sourceStationId, int destionationStationId);
        void ReleaseTrackToken(int sourceStationId, int destionationStationId);
        void AcquireTrackToken(int sourceStationId, int destionationStationId,int trainId);
    }
}
