using BlueStacks.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.BusinessLogic
{
    public sealed class TrackTokenController : ITrackTokenController
    {
        private object _lock = new object();
        private Dictionary<string, int> _dicTokens = new Dictionary<string, int>();
        private readonly static TrackTokenController _instance = new TrackTokenController();

        private TrackTokenController()
        {
        }

        public static TrackTokenController GetInstance()
        {
            return _instance;
        }

        public bool CheckTrackTokenAvailability(int sourceStationId, int destionationStationId)
        {
            lock (_lock)
            {
                string searchKey = sourceStationId.ToString() + "To" + destionationStationId.ToString();
                if (_dicTokens.ContainsKey(searchKey))
                {
                    if (_dicTokens[searchKey] == -1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    _dicTokens.Add(searchKey, -1);
                    return false;
                }
                
            }
        }

        public void ReleaseTrackToken(int sourceStationId, int destionationStationId)
        {
            string searchKey = sourceStationId.ToString() + "To" + destionationStationId.ToString();
            lock (_lock)
            {
                if (_dicTokens.ContainsKey(searchKey))
                    _dicTokens[searchKey] = -1;
            }
        }

        public void AcquireTrackToken(int sourceStationId, int destionationStationId, int trainId)
        {
            lock (_lock)
            {
                string searchKey = sourceStationId.ToString() + "To" + destionationStationId.ToString();
                if (_dicTokens.ContainsKey(searchKey))
                    _dicTokens[searchKey] = trainId;
            }
        }

    }
}
