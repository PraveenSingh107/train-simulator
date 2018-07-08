using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueStacks.Core.BusinessObjects
{
    public class Shipment
    {

        #region Properties

        private double _shipmentIdentifier;
        public double ShipmentIdentifier
        {
            get { return _shipmentIdentifier; }
        }
        
        private Station _sourceStation;
        public Station SourceStation
        {
            get { return _sourceStation; }
        }

        private Station _destinationStation;
        public Station DestinationStation
        {
            get { return _destinationStation; }
        }

        #endregion Properties

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="sourceStation">Source Station</param>
        /// <param name="destinationStation">Destination Station</param>
        public Shipment(Station sourceStation, Station destinationStation)
        {
            this._shipmentIdentifier = DateTime.Now.Ticks;
            this._sourceStation = sourceStation;
            this._destinationStation = destinationStation;
        }

        public override string ToString()
        {
            return "[" + SourceStation.ToString() + " :: " + DestinationStation.ToString() + "]"; 
        }
    }
}
