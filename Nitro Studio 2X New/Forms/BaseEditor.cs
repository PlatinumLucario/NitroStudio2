using Eto.Drawing;
using Eto.Forms;
using GotaSequenceLib;
using GotaSequenceLib.Playback;
using NitroFileLoader;
using NitroStudio2X.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NitroStudio2X.Forms
{
	public partial class BaseEditor : Form
	{
        SoundArchive SA = new SoundArchive();
        Configuration Config = new Configuration();
        Mixer Mixer;
        Player Player;

        // Controls
        StackLayout stackLayout = new StackLayout();
		ListBox itemsList = new ListBox();
        public BaseEditor()
		{
            // Handlers to safely close
            this.Load += BaseEditor_Load;
            this.Closed += BaseEditor_Closed;

			// Stack Layout
			stackLayout.Items.Add("Hello World");
			stackLayout.Items.Add(itemsList);
			stackLayout.Width = 500;
			stackLayout.Orientation = Orientation.Horizontal;
			stackLayout.Padding = 10;

            // TreeView
            itemsList.Width = 750;
            itemsList.Height = 660;

			Title = "Nitro Studio 2X (Dev)";
			MinimumSize = new Size(1000, 670);
			Content = stackLayout;
			// create a few commands that can be used for the menu and toolbar

			var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			// Open Button
			var btnOpen = new Command { MenuText = "Open", Shortcut = Application.Instance.CommonModifier | Keys.O };
            btnOpen.Executed += BtnOpen_Executed;

			// Play Test
			var btnTestPlay = new Command { MenuText = "Play"};
            btnTestPlay.Executed += BtnTestPlay_Executed;



            // create menu
            Menu = new MenuBar
			{
				Items =
				{
					// File submenu
					new SubMenuItem { Text = "&File", Items = {btnOpen} },
					new SubMenuItem { Text = "&Edit", Items = { } },
					new SubMenuItem { Text = "&Tools", Items = { /* commands/items */ } },
                    new SubMenuItem { Text = "&Help", Items = { /* commands/items */ } },
                    new SubMenuItem { Text = "&About", Items = { /* commands/items */ } },
                    new SubMenuItem { Text = "&Debug", Items = { btnTestPlay } },
                },
				ApplicationItems =
				{
					// application (OS X) or file menu (others)
					
				},
				QuitItem = quitCommand,
			};
		}

        private void BaseEditor_Closed(object sender, EventArgs e)
        {
            if(Player.State == PlayerState.Playing)
            {
                Player.Stop();
            }
        }

        private void ReloadConfig()
        {
            // status.Text = "Reloading Configuration...";
            Config = new Configuration();
            if (Player.State == PlayerState.Playing)
            {
                long pos = Player.GetCurrentPosition();
                List<SequenceCommand> sc = Player.Events;
                var bnk = Player.Banks;
                var wav = Player.WaveArchives;
                Player.Stop();
                Mixer = new Mixer(Config.Settings["outputWaveDevice"]);
                // HandleChecks.Start();
                Player = new Player(Mixer);
                Config.WriteConfig();
                Player.PrepareForSong(bnk, wav);
                Player.LoadSong(sc);
                Player.Play();
                Player.SetCurrentPosition(pos);
            }
            else
            {
                Mixer = new Mixer(Config.Settings["outputWaveDevice"]);
                // HandleChecks.Start();
                Player = new Player(Mixer);
                Config.WriteConfig();
            }
            UpdateListing();
        }

        private void BaseEditor_Load(object sender, EventArgs e)
        {
            Mixer = new Mixer(Config.Settings["outputWaveDevice"]);
            Player = new Player(Mixer);
        }

        private void BtnTestPlay_Executed(object sender, EventArgs e)
        {
            var s = SA.Sequences.Where(x => x.Index == itemsList.SelectedIndex).FirstOrDefault();
            try { Player.PrepareForSong(new PlayableBank[] { s.Bank.File }, s.Bank.GetAssociatedWaves()); } catch { MessageBox.Show("Sequence entry has no valid bank hooked up to it!"); return; }
            s.File.ReadCommandData();
            Player.LoadSong(s.File.Commands);
            Player.Play();
        }

        private void UpdateListing()
		{
			itemsList.Items.Clear();
			foreach(var f in SA.Sequences) {
				itemsList.Items.Add(f.Name);
			}
		}

        private void BtnOpen_Executed(object sender, EventArgs e)
        {
			OpenFileDialog o = new OpenFileDialog();
			o.Filters.Add(new FileFilter("Sound Archive", ".sdat"));
			if(o.ShowDialog(this) == DialogResult.Ok)
			{
				SA = new SoundArchive(o.FileName);
				UpdateListing();
			}
        }
    }
}
