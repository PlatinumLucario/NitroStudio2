using GotaSoundIO.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitroStudio2
{
    public partial class HeapChecker : Form
    {
        int heap_used = 0;
        int heap_size = 0;
        public HeapChecker(int used, int size)
        {
            InitializeComponent();
            heap_size = size;
            heap_used = used;
        }

        public static string GetBytesSize(int byteCount)
        {
            string[] suf = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        private void HeapChecker_Load(object sender, EventArgs e)
        {
            if(heap_size <= 0)
            {
                MessageBox.Show("Unable to show heap calculation for Players with a heap size less than 0. Heap used is " + GetBytesSize(heap_used), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            pVisual.Maximum = heap_size;
            double d = heap_used / heap_size;
            if (d > 100)
            {
                pVisual.Value = heap_size;
                pVisual.ForeColor = Color.Red;
            }
            else if (d > 90)
            {
                pVisual.Value = heap_used;
                pVisual.ForeColor = Color.Red;
            }
            else if (d > 70)
            {
                pVisual.Value = heap_used;
                pVisual.ForeColor = Color.Yellow;
            }
            else
            {
                pVisual.Value = heap_used;
            }
            lUsage.Text = "Heap Usage: " + GetBytesSize(heap_used) + " / " + GetBytesSize(heap_size) + "(" + (Math.Round(d))*100 + "%)";
            lRemain.Text = "Heap Remaining: " + GetBytesSize(heap_size - heap_used);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
