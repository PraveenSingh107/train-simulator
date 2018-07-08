using BlueStacks.Core.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BlueStacks.Core.BusinessLogic
{
    public sealed class GlobalClock
    {

        # region Data Members
        private static readonly GlobalClock _singletonInstance = new GlobalClock();
        public static event EventHandler<StationShipmentEventArgs> StationShipmentArrived;
        public static event EventHandler GlobalClockTimeChanged;
        private static Timer _timer;
        private volatile static int _timeTickCounter = 0;
        private static Random _randomNumberGenerator;
        private static int _upperBoundaryForStationNumberGenerator;
        # endregion Data Members

        private GlobalClock()
        {
        }

        public static GlobalClock GetInstance()
        {
            return _singletonInstance;
        }

        /// <summary>
        /// Starts the whole system
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="noOfStations"></param>
        public void Start(int seconds, int noOfStations)
        {
            //Console.WriteLine("\r\n Hi Global counter started.");
            _randomNumberGenerator = new Random();
            _upperBoundaryForStationNumberGenerator = noOfStations + 1;
            _timer = new Timer();
            _timer.Interval = seconds * 1000;
            _timer.Elapsed += OnGlobalClockedElapsed;
            StationShipmentHandler.GetInstance().Start();
            TrainSystemSimulator.GetInstance().Start();
            _timer.Start();

        }

        private void OnEveryTick(object sender)
        {
            var globalClockTimeChanged = GlobalClockTimeChanged;
            if (globalClockTimeChanged != null)
            {
                globalClockTimeChanged(sender, null);
            }
        }

        private void OnGlobalClockedElapsed(object sender, ElapsedEventArgs e)
        {

            OnEveryTick(sender);

            _timeTickCounter++;
            if (_timeTickCounter == 2)
            {
                int firstRandomNumber = _randomNumberGenerator.Next(1, _upperBoundaryForStationNumberGenerator);
                int secondRandomNumber = _randomNumberGenerator.Next(1, _upperBoundaryForStationNumberGenerator);
                int thirdRandomNumber = _randomNumberGenerator.Next(1, _upperBoundaryForStationNumberGenerator);
                if ((firstRandomNumber != secondRandomNumber) && (firstRandomNumber > thirdRandomNumber || secondRandomNumber < thirdRandomNumber))
                {
                    StationShipmentEventArgs eventArgs = new StationShipmentEventArgs(firstRandomNumber, secondRandomNumber);
                    OnStationShipmentArrival(_singletonInstance, eventArgs);
                }
                _timeTickCounter = 0;
            }
        }

        private void OnStationShipmentArrival(object sender, StationShipmentEventArgs eventArgs)
        {
            var shipmentEvent = StationShipmentArrived;
            if (shipmentEvent != null)
            {
                shipmentEvent(sender, eventArgs);
            }
        }

        public void Cleanup()
        {
            _timer.Elapsed -= OnGlobalClockedElapsed;
            _timer.Stop();

        }
    }
}
