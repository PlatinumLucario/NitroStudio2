using GotaSequenceLib;
using System;
using System.Collections.Generic;
using System.Text;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using System.Diagnostics;

namespace NitroStudio2.Functions.NewConverters
{
    public static class SequenceConverter
    {
        public static void MakeFromMidi(string filename)
        {
            List<SequenceCommand> Commands = new List<SequenceCommand>();
            MidiFile mid = MidiFile.Read(filename);
            foreach(var track in mid.GetTrackChunks())
            {
                foreach(var ev in track.Events)
                {
                    Debug.WriteLine(ev.EventType);
                }
            }
        }
    }
}
