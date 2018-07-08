using BlueStacks.Core.BusinessLogic;
using BlueStacks.Core.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacks.Core.Interfaces
{
    public interface IStationShipmentHandler
    {
        void ProcessQueuedShipment();

        bool QueueArrivedShipment(object sender, StationShipmentEventArgs eventArgs);

        void CleanUp();
    }
}
