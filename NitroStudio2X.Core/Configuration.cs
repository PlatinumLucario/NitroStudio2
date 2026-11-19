using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using System.Windows.Forms;

namespace NitroStudio2X.Core
{
    public static class Global
    {
        public static string version = "27.01-beta1";
        public static Configuration c = new Configuration();
    }
    public class Configuration
    {
        string GetConfigPath()
        {
            string path = "";
            if(OperatingSystem.IsWindows())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NitroStudio2\\config.ini";
            } else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.config\\NitroStudio2\\config.ini";
            }
            return path;
        }

        public static string WriteStackTraceLog(Exception e)
        {
            string path = "";
            DateTime t = DateTime.Now;
            string time = t.Year + "-" + t.Month + "-" + t.Day + " " + t.Hour + "." + t.Minute + "-" + t.Second;
            if (OperatingSystem.IsWindows())
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NitroStudio2\\Logs\\";
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.config\\NitroStudio2\\Logs\\";
            }
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllLines(path + time + ".log", new string[]
            {
                "Time of Exception: " + t,
                "NitroStudio2X Version: " + Global.version,
                "Type: " + e.GetType(),
                "Message: " + e.Message,
                "OS: " + System.Environment.OSVersion,
                "Runtime: " + System.Environment.Version,
                "\nStack Trace: \n" + e.StackTrace
            });
            return path + time + ".log";
        }

        public Dictionary<string, string> Settings = new Dictionary<string, string> {
            { "version", Global.version},
            { "writeNames", "true" },
            { "importTool", "NitroStudio" },
            { "exportTool", "NitroStudio" },
            { "inputMidiDevice", "0" },
            { "outputWaveDevice", ConfigurationDefaults.GetDefaultWaveDevice()},
            { "viewHeap", "hex"},
            { "showVirtualPiano", "true" },

        };

        public void ReadConfig(StreamReader r)
        {
            if (r.ReadLine() == "[NitroStudio2]")
            {
                r.Close();
                foreach (string l in File.ReadAllLines(GetConfigPath()))
                {
                    if (l != "[NitroStudio2]")
                    {
                        if (!l.StartsWith("#"))
                        {
                            string[] setting = l.Replace(" ", "").Replace("\t", "").Split('=');
                            if (Settings.ContainsKey(setting.First()))
                            {
                                Settings[setting.First()] = setting.Last().Split('#').First();
                            } else
                            {
                                Settings.Add(setting.First(), setting.Last().Split('#').First());
                            }
                        }
                    }
                }
                GenerateConfig(false);
                if (Settings["version"] != Global.version)
                {
                    Settings["version"] = Global.version;
                }
            }
            else
            {
                r.Close();
                GenerateConfig(true);
            }
        }

        public void GenerateConfig(bool reset)
        {
            if(reset) {
                Settings.Clear();
            }
            /* foreach(string key in ConfigurationDefaults.Defaults.Keys)
            {
                if(!Settings.ContainsKey(key))
                {
                    Settings.Add(key, ConfigurationDefaults.Defaults[key]);
                }
            } */
            WriteConfig();
        }

        public void WriteConfig()
        {
            if (!Directory.Exists(GetConfigPath().Replace("\\config.ini", "")))
            {
                Directory.CreateDirectory(GetConfigPath().Replace("\\config.ini", ""));
            }
            using (StreamWriter w = new StreamWriter(GetConfigPath()))
            {
                w.WriteLine("[NitroStudio2]");
                foreach (var s in Settings.Keys)
                {
                    w.WriteLine(s + " = " + Settings[s]);
                }
            }
        }

        public Configuration()
        {
            if (File.Exists(GetConfigPath()))
            {
                ReadConfig(new StreamReader(GetConfigPath()));
            }
            else
            {
                GenerateConfig(true);
            }
        }
    }
}

