using NitroFileLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitroStudio2
{
    public partial class ImportFromSdatTool : Form
    {
        SoundArchive SA;
        public string Format;
        public bool Result = false;
        public byte[] FileData;
        public ImportFromSdatTool()
        {
            InitializeComponent();
        }

        private void ImportFromSdatTool_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SDAT File|*.sdat";
            ofd.Multiselect = false;
            DialogResult r = ofd.ShowDialog();
            if (r == DialogResult.OK)
            {
                SA = new SoundArchive(ofd.FileName);
                switch(Format.ToLower())
                {
                    case "sequences":
                        foreach(var s in SA.Sequences)
                        {
                            filesDrop.Items.Add("[" + s.Index + "] " + s.Name);
                        }
                        filesDrop.SelectedIndex = 0;
                        break;
                    case "sequencearchives":
                        foreach (var s in SA.SequenceArchives)
                        {
                            filesDrop.Items.Add("[" + s.Index + "] " + s.Name);
                        }
                        filesDrop.SelectedIndex = 0;
                        break;
                    case "banks":
                        foreach (var s in SA.Banks)
                        {
                            filesDrop.Items.Add("[" + s.Index + "] " + s.Name);
                        }
                        filesDrop.SelectedIndex = 0;
                        break;
                    case "wavearchives":
                        foreach (var s in SA.WaveArchives)
                        {
                            filesDrop.Items.Add("[" + s.Index + "] " + s.Name);
                        }
                        filesDrop.SelectedIndex = 0;
                        break;
                    case "streams":
                        foreach (var s in SA.Streams)
                        {
                            filesDrop.Items.Add("[" + s.Index + "] " + s.Name);
                        }
                        filesDrop.SelectedIndex = 0;
                        break;
                    default:
                        MessageBox.Show("Selected File cannot be a Group or Player file");
                        Close();
                        break;
                }
            } else
            {
                Close();
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            Result = true;
            int id = int.Parse(filesDrop.Text.Split(' ').First().Replace("[", "").Replace("]", ""));
            Debug.WriteLine(id);
            switch (Format.ToLower())
            {
                case "sequences":
                    foreach(var s in SA.Sequences)
                    {
                        if(s.Index == id)
                        {
                            
                            FileData = s.File.Write();
                            break;
                        }
                    }
                    break;
                case "sequencearchives":
                    foreach (var s in SA.SequenceArchives)
                    {
                        if (s.Index == id)
                        {
                            FileData = s.File.Write();
                            break;
                        }
                    }
                    break;
                case "banks":
                    foreach (var s in SA.Banks)
                    {
                        if (s.Index == id)
                        {
                            FileData = s.File.Write();
                            break;
                        }
                    }
                    break;
                case "wavearchives":
                    foreach (var s in SA.WaveArchives)
                    {
                        if (s.Index == id)
                        {
                            FileData = s.File.Write();
                            break;
                        }
                    }
                    break;
                case "streams":
                    foreach (var s in SA.Streams)
                    {
                        if (s.Index == id)
                        {
                            FileData = s.File.Write();
                            break;
                        }
                    }
                    break;
            }
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
