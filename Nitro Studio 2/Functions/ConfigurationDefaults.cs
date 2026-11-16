using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroStudio2.Functions
{
    public static class ConfigurationDefaults
    {
        public static string GetDefaultWaveDevice()
        {
            string deviceId;
            try {
                deviceId = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Console).ID;
            }
            catch {
                deviceId = "0";
            }
            return deviceId;
        }
    }
}
