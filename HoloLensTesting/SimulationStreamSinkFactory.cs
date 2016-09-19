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
        private Uri deviceIpAddress;

        public SimulationStreamSinkFactory(Uri deviceIpAddress)
        {
            this.deviceIpAddress = deviceIpAddress;
        }

        public ISimulationStreamSink CreateSimulationStreamSink()
        {
            var task = Task.Run(async () => 
                            await RestSimulationStreamSink.Create(
                                    // use the IP address for your device/emulator
                                    deviceIpAddress,
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
