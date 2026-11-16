using Eto.Drawing;
using Eto.Forms;
using GotaSequenceLib;
using GotaSequenceLib.Playback;
using NitroFileLoader;
using NitroStudio2X.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NitroStudio2X.Forms
{
	public partial class BaseEditor : Form
	{
        // For the Engine
        SoundArchive SA = new SoundArchive();
        Configuration Config = new Configuration();
        Mixer Mixer;
        Player Player;

        int sseq_start = 0;
        int ssar_start = 0;
        int sbnk_start = 0;
        int swar_start = 0;
        int sply_start = 0;
        int sgrp_start = 0;
        int stpl_start = 0;
        int strm_start = 0;

        // Controls
        TreeGridView EntryList = new TreeGridView();
        TreeGridItemCollection Items = new TreeGridItemCollection();

        TreeGridItem sseqList = new TreeGridItem(new string[] { "Sequences" });
        TreeGridItem ssarList = new TreeGridItem(new string[] { "Sequence Archives" });
        TreeGridItem sbnkList = new TreeGridItem(new string[] { "Instrument Banks" });
        TreeGridItem swarList = new TreeGridItem(new string[] {"Wave Archives" });
        TreeGridItem splyList = new TreeGridItem(new string[] { "Sequence Players" });
        TreeGridItem sgrpList = new TreeGridItem(new string[] { "Groups" });
        TreeGridItem stplList = new TreeGridItem(new string[] { "Stream Players" });
        TreeGridItem strmList = new TreeGridItem(new string[] { "Streams" });


        public BaseEditor()
		{
            // Generate Headers
            GridColumn c1 = new GridColumn();
            c1.HeaderText = "ID";
            c1.Editable = false;
            c1.DataCell = new TextBoxCell(0);
            EntryList.Columns.Add(c1);

            // Initialise
            Items.Add(sseqList);
            Items.Add(ssarList);
            Items.Add(sbnkList);
            Items.Add(swarList);
            Items.Add(splyList);
            Items.Add(sgrpList);
            Items.Add(stplList);
            Items.Add(strmList);

            EntryList.DataStore = Items;



            // Handlers to safely close
            this.Load += BaseEditor_Load;
            this.Closed += BaseEditor_Closed;

			Title = "Nitro Studio 2X (Dev)";
			MinimumSize = new Size(1000, 670);
			Content = EntryList;
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
            if(Player.State == PlayerState.Playing)
            {
                Player.Stop();
            }
            
            var s = SA.Sequences.Where(x => x.Index == GetActualID(EntryList.SelectedRow, "sseq")).FirstOrDefault();
            try { Player.PrepareForSong(new PlayableBank[] { s.Bank.File }, s.Bank.GetAssociatedWaves()); } catch { MessageBox.Show("Sequence entry has no valid bank hooked up to it!"); return; }
            s.File.ReadCommandData();
            Player.LoadSong(s.File.Commands);
            Player.Play();
            var x = (TreeGridItem)(EntryList.SelectedItem.Parent);
            MessageBox.Show(x.Values.First().ToString());
        }

        private int GetActualID(int id, string format)
        {
            switch(format.ToLower())
            {
                case "sseq":
                    return SA.Sequences[id - 1].Index;
                    break;
            }
            return -1;
        }

        private void UpdateListing()
		{
            Items.Clear();
			sseqList.Children.Clear();
            ssarList.Children.Clear();
            sbnkList.Children.Clear();
            swarList.Children.Clear();
            splyList.Children.Clear();
            sgrpList.Children.Clear();
            stplList.Children.Clear();
            strmList.Children.Clear();
            int i = 0;
            foreach (var f in SA.Sequences) {
                sseq_start = i;
				sseqList.Children.Add(new TreeGridItem(new string[] {"[" + f.Index.ToString() + "] " + f.Name }));
                i++;
			}
            foreach (var f in SA.SequenceArchives)
            {
                ssar_start = i;
                ssarList.Children.Add(new TreeGridItem(new string[] { "[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            foreach (var f in SA.Banks)
            {
                sbnk_start = i;
                sbnkList.Children.Add(new TreeGridItem(new string[] {"[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            foreach (var f in SA.WaveArchives)
            {
                swar_start = i;
                swarList.Children.Add(new TreeGridItem(new string[] { "[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            foreach (var f in SA.Players)
            {
                sply_start = i;
                splyList.Children.Add(new TreeGridItem(new string[] {"[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            foreach (var f in SA.Groups)
            {
                sgrp_start = i;
                sgrpList.Children.Add(new TreeGridItem(new string[] {"[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            foreach (var f in SA.StreamPlayers)
            {
                stpl_start = i;
                stplList.Children.Add(new TreeGridItem(new string[] {"[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            foreach (var f in SA.Streams)
            {
                strm_start = i;
                strmList.Children.Add(new TreeGridItem(new string[] {"[" + f.Index.ToString() + "] " + f.Name }));
                i++;
            }
            Items.Add(sseqList);
            Items.Add(ssarList);
            Items.Add(sbnkList);
            Items.Add(swarList);
            Items.Add(splyList);
            Items.Add(sgrpList);
            Items.Add(stplList);
            Items.Add(strmList);
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
