using Microsoft.PerceptionSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloLensTesting
{
    class Program
    {
        private static Uri deviceIpAddress = new Uri("http://169.254.106.72/");

        static void Main(string[] args)
        {
            AutomateHoloLens();

            //PlayRecordedFile();

            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }

        private static async Task AutomateHoloLens()
        {

        }

        private static void PlayRecordedFile()
        {

        }
    }
}
