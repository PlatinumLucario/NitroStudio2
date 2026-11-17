using GotaSequenceLib;
using GotaSequenceLib.Playback;
using GotaSoundIO.Sound;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class SequenceRecorder : Form {

        /// <summary>
        /// Mixer.
        /// </summary>
        public Mixer Mixer;

        /// <summary>
        /// Player.
        /// </summary>
        Player Player;

        /// <summary>
        /// Commands.
        /// </summary>
        private List<SequenceCommand> commands;

        /// <summary>
        /// Sequence start.
        /// </summary>
        private int seqStart;

        /// <summary>
        /// File path.
        /// </summary>
        private string filePath;
        private Functions.Configuration Config = new Functions.Configuration();

        /// <summary>
        /// Create a new sequence recorder.
        /// </summary>
        /// <param name="banks">The banks.</param>
        /// <param name="wars">Wave archives.</param>
        /// <param name="commands">Sequence commands.</param>
        /// <param name="startIndex">Start index.</param>
        public SequenceRecorder(PlayableBank[] banks, RiffWave[][] wars, List<SequenceCommand> commands, int startIndex, string filePath) {

            //Init.
            InitializeComponent();
            Config = new Functions.Configuration();
            Mixer = new Mixer(Config.Settings["outputWaveDevice"]);
            //Load stuff.
            Player = new Player(Mixer);
            Player.PrepareForSong(banks, wars);
            this.commands = commands;
            this.seqStart = startIndex;
            this.filePath = filePath;

        }

        void SaveFile()
        {
            Player.Record(filePath);
        }

        /// <summary>
        /// Record the sequence.
        /// </summary>
        private void exportButton_Click(object sender, EventArgs e) {
            exportButton.Visible = false;
            progressBar1.Visible = true;
            tableLayoutPanel1.Visible = false;
            lbUpdate.Visible = true;
            Player.LoadSong(commands, seqStart);
            Player.NumLoops = (long)loopsBox.Value;
            Player.DontFadeSong = !fadeBox.Checked;
            progressBar1.Maximum = (int)Player.MaxTicks;
            Thread t = new Thread(new ThreadStart(SaveFile));
            //Save.
            t.Start();
            while(t.IsAlive)
            {
                lbUpdate.Text = TimeSpan.FromTicks(Player.GetCurrentPosition()) + "/" + TimeSpan.FromTicks(Player.MaxTicks) + " exported";
                progressBar1.Value = (int)Player.GetCurrentPosition();
            }
            Close();
        }

        private void SequenceRecorder_Load(object sender, EventArgs e)
        {
            exportButton.Visible = true;
            progressBar1.Visible = false;
            tableLayoutPanel1.Visible = true;
            lbUpdate.Visible = false;
        }
    }
}
