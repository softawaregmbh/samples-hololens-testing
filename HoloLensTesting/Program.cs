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
            var manager =PerceptionSimulationManager.CreatePerceptionSimulationManager(
                new SimulationStreamSinkFactory(deviceIpAddress).CreateSimulationStreamSink());

            for (int i = 0; i < 5; i++)
            {
                manager.Human.RightHand.PerformGesture(SimulatedGesture.FingerPressed);
                await Task.Delay(300);
                manager.Human.RightHand.PerformGesture(SimulatedGesture.FingerReleased);

                await Task.Delay(1000);
                manager.Human.Head.Rotate(new Rotation3(0f, 0.2f, 0.0f));

                await Task.Delay(300);
            }
        }

        private static void PlayRecordedFile()
        {
            var recording = PerceptionSimulationManager.LoadPerceptionSimulationRecording(@"OpenBrowser.xef", new SimulationStreamSinkFactory(deviceIpAddress));

            recording.Play();
        }
    }
}
