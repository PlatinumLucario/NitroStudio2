using GotaSoundIO.Sound;
using NitroFileLoader;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitroStudio2.Functions
{
    public static class Builders
    {

        public static WaveArchive WaveFromSwls(string swls)
        {
            FileInfo i = new FileInfo(swls);
            
            string path = i.DirectoryName;

            string[] lines = File.ReadAllLines(swls);
            
            WaveArchive a = new WaveArchive();

            foreach(string s in lines)
            {
                Wave w = new Wave();
                if (s.EndsWith(".swav"))
                {
                    w.Read(path + "\\" + s);
                } else
                {
                    RiffWave r = new RiffWave(path + "\\" + s);
                    w.FromOtherStreamFile(r);
                }
                a.Waves.Add(w);
            }

            return a;
        }
    }
}
