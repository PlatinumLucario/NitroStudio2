namespace NitroStudio2
{
    partial class HeapChecker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lWarn = new System.Windows.Forms.Label();
            this.pVisual = new System.Windows.Forms.ProgressBar();
            this.lRemain = new System.Windows.Forms.Label();
            this.lUsage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lWarn
            // 
            this.lWarn.AutoSize = true;
            this.lWarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWarn.Location = new System.Drawing.Point(6, 9);
            this.lWarn.Name = "lWarn";
            this.lWarn.Size = new System.Drawing.Size(328, 26);
            this.lWarn.TabIndex = 0;
            this.lWarn.Text = "This only checks the track against the associated player\r\nheap, and will not be 1" +
    "00% accurate.\r\n";
            // 
            // pVisual
            // 
            this.pVisual.Location = new System.Drawing.Point(9, 62);
            this.pVisual.Name = "pVisual";
            this.pVisual.Size = new System.Drawing.Size(344, 23);
            this.pVisual.TabIndex = 3;
            // 
            // lRemain
            // 
            this.lRemain.AutoSize = true;
            this.lRemain.Location = new System.Drawing.Point(12, 46);
            this.lRemain.Name = "lRemain";
            this.lRemain.Size = new System.Drawing.Size(89, 13);
            this.lRemain.TabIndex = 2;
            this.lRemain.Text = "Heap Remaining:";
            // 
            // lUsage
            // 
            this.lUsage.AutoSize = true;
            this.lUsage.Location = new System.Drawing.Point(12, 91);
            this.lUsage.Name = "lUsage";
            this.lUsage.Size = new System.Drawing.Size(112, 13);
            this.lUsage.TabIndex = 4;
            this.lUsage.Text = "X bytes / X bytes (X%)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HeapChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 117);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lUsage);
            this.Controls.Add(this.pVisual);
            this.Controls.Add(this.lRemain);
            this.Controls.Add(this.lWarn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeapChecker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Heap Check for XXX";
            this.Load += new System.EventHandler(this.HeapChecker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lWarn;
        private System.Windows.Forms.ProgressBar pVisual;
        private System.Windows.Forms.Label lRemain;
        private System.Windows.Forms.Label lUsage;
        private System.Windows.Forms.Button button1;
    }
}