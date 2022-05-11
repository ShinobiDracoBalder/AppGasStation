using Common.GasStation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppGasStation
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadPlaceXml xmlPlace = new ReadPlaceXml();
            xmlPlace.ReadDirectoryPlace();
            Console.ReadKey();
        }
    }
}
