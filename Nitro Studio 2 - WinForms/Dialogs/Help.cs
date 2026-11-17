using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NitroStudio2.Dialogs
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var dir in Directory.GetDirectories("Docs"))
            {
                pageList.Nodes.Add(dir, dir.Split("\\").Last(), 1);
                foreach (var file in Directory.GetFiles(dir))
                {
                    FileInfo f = new FileInfo(file);
                    pageList.Nodes[i].Nodes.Add(file, f.Name.Replace(".rtf", ""), 0);
                }
                i++;
            }
            foreach (var file in Directory.GetFiles("Docs"))
            {
                FileInfo f = new FileInfo(file);
                pageList.Nodes.Add(file, f.Name.Replace(".rtf", ""), 0);
            }
            helpDocument.LoadFile("Docs\\Welcome.rtf");
        }

        private void pageList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (pageList.SelectedNode.Name.EndsWith(".rtf"))
            {
                helpDocument.LoadFile(pageList.SelectedNode.Name);
                pageList.SelectedImageIndex = 0;
            }
            else
            {
                pageList.SelectedImageIndex = 1;
            }
        }

        private void helpDocument_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            ProcessStartInfo i = new ProcessStartInfo();
            i.FileName = e.LinkText;
            i.UseShellExecute = true;
            Process.Start(i);
        }
    }
}
