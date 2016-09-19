using Microsoft.PerceptionSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloLensTesting
{
    public class SimulationStreamSinkFactory : ISimulationStreamSinkFactory
    {
        public ISimulationStreamSink CreateSimulationStreamSink()
        {
            var task = Task.Run(async () => 
                            await RestSimulationStreamSink.Create(
                                    // use the IP address for your device/emulator
                                    new Uri("http://169.254.106.72/"),
                                    // no credentials are needed for the emulator
                                    new System.Net.NetworkCredential("", ""),
                                    // normal priorty
                                    true,
                                    // cancel token
                                    new System.Threading.CancellationToken())
                                    );

            return task.Result;
        }
    }
}
