using BlueStacks.Core;
using BlueStacks.Core.BusinessLogic;
using BlueStacks.Core.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStacksCodingAssignment
{
    class Program
    {
        static int noOfStations = 8;
        static int noOfTrains = 4;
        static int[] speeds = new Int32[noOfTrains];
        static int[] distances = new Int32[noOfStations];
        static int[] shipmentCapacity = new Int32[noOfTrains];

        static void Main(string[] args)
        {
            SetupConstants();
            Initializer();

            GlobalClock.GetInstance().Start(1, noOfStations);

            Console.Read();
        }

        private static void SetupConstants()
        {
           
        }

        private static void Initializer()
        {
            

            
        }
    }
}
