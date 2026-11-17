namespace NitroStudio2
{
    partial class Settings
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
            lImportTool = new System.Windows.Forms.Label();
            lExportTool = new System.Windows.Forms.Label();
            btnCancel = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            writeNames = new System.Windows.Forms.CheckBox();
            comboImport = new System.Windows.Forms.ComboBox();
            comboExport = new System.Windows.Forms.ComboBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            saSettings = new System.Windows.Forms.TabPage();
            sdSettings = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            cbWaveOutput = new System.Windows.Forms.ComboBox();
            lblInput = new System.Windows.Forms.Label();
            cbMidiInput = new System.Windows.Forms.ComboBox();
            inSettings = new System.Windows.Forms.TabPage();
            virtualPiano = new System.Windows.Forms.CheckBox();
            comboHeap = new System.Windows.Forms.ComboBox();
            lHeapsizes = new System.Windows.Forms.Label();
            tabControl1.SuspendLayout();
            saSettings.SuspendLayout();
            sdSettings.SuspendLayout();
            inSettings.SuspendLayout();
            SuspendLayout();
            // 
            // lImportTool
            // 
            lImportTool.AutoSize = true;
            lImportTool.Location = new System.Drawing.Point(5, 43);
            lImportTool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lImportTool.Name = "lImportTool";
            lImportTool.Size = new System.Drawing.Size(88, 15);
            lImportTool.TabIndex = 1;
            lImportTool.Text = "Import Method";
            // 
            // lExportTool
            // 
            lExportTool.AutoSize = true;
            lExportTool.Location = new System.Drawing.Point(5, 74);
            lExportTool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lExportTool.Name = "lExportTool";
            lExportTool.Size = new System.Drawing.Size(85, 15);
            lExportTool.TabIndex = 2;
            lExportTool.Text = "Export Method";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(5, 376);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(88, 27);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new System.Drawing.Point(252, 376);
            btnApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(88, 27);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(346, 376);
            btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(88, 27);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // writeNames
            // 
            writeNames.AutoSize = true;
            writeNames.Checked = true;
            writeNames.CheckState = System.Windows.Forms.CheckState.Checked;
            writeNames.Location = new System.Drawing.Point(7, 7);
            writeNames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            writeNames.Name = "writeNames";
            writeNames.Size = new System.Drawing.Size(139, 19);
            writeNames.TabIndex = 6;
            writeNames.Text = "Write Names of Files?";
            writeNames.UseVisualStyleBackColor = true;
            writeNames.CheckedChanged += writeNames_CheckedChanged;
            // 
            // comboImport
            // 
            comboImport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboImport.FormattingEnabled = true;
            comboImport.Items.AddRange(new object[] { "Nitro Studio", "Midi2Sseq", "Nintendo Tools" });
            comboImport.Location = new System.Drawing.Point(99, 39);
            comboImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboImport.Name = "comboImport";
            comboImport.Size = new System.Drawing.Size(235, 23);
            comboImport.TabIndex = 7;
            comboImport.SelectedIndexChanged += comboImport_SelectedIndexChanged;
            comboImport.SelectionChangeCommitted += comboImport_SelectionChangeCommitted;
            // 
            // comboExport
            // 
            comboExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboExport.FormattingEnabled = true;
            comboExport.Items.AddRange(new object[] { "Nitro Studio", "Sseq2Midi" });
            comboExport.Location = new System.Drawing.Point(99, 70);
            comboExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboExport.Name = "comboExport";
            comboExport.Size = new System.Drawing.Size(235, 23);
            comboExport.TabIndex = 8;
            comboExport.SelectedIndexChanged += comboExport_SelectedIndexChanged;
            comboExport.SelectionChangeCommitted += comboExport_SelectionChangeCommitted;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(saSettings);
            tabControl1.Controls.Add(sdSettings);
            tabControl1.Controls.Add(inSettings);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(455, 369);
            tabControl1.TabIndex = 9;
            // 
            // saSettings
            // 
            saSettings.Controls.Add(writeNames);
            saSettings.Controls.Add(comboExport);
            saSettings.Controls.Add(lImportTool);
            saSettings.Controls.Add(comboImport);
            saSettings.Controls.Add(lExportTool);
            saSettings.Location = new System.Drawing.Point(4, 24);
            saSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saSettings.Name = "saSettings";
            saSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saSettings.Size = new System.Drawing.Size(447, 341);
            saSettings.TabIndex = 0;
            saSettings.Text = "Sound Archive";
            saSettings.UseVisualStyleBackColor = true;
            // 
            // sdSettings
            // 
            sdSettings.Controls.Add(label1);
            sdSettings.Controls.Add(cbWaveOutput);
            sdSettings.Controls.Add(lblInput);
            sdSettings.Controls.Add(cbMidiInput);
            sdSettings.Location = new System.Drawing.Point(4, 24);
            sdSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sdSettings.Name = "sdSettings";
            sdSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sdSettings.Size = new System.Drawing.Size(447, 341);
            sdSettings.TabIndex = 1;
            sdSettings.Text = "Sound Device";
            sdSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 35);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 15);
            label1.TabIndex = 3;
            label1.Text = "Wave Output";
            // 
            // cbWaveOutput
            // 
            cbWaveOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbWaveOutput.FormattingEnabled = true;
            cbWaveOutput.Location = new System.Drawing.Point(97, 31);
            cbWaveOutput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbWaveOutput.Name = "cbWaveOutput";
            cbWaveOutput.Size = new System.Drawing.Size(332, 23);
            cbWaveOutput.TabIndex = 2;
            cbWaveOutput.SelectedIndexChanged += cbWaveOutput_SelectedIndexChanged;
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new System.Drawing.Point(7, 7);
            lblInput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblInput.Name = "lblInput";
            lblInput.Size = new System.Drawing.Size(63, 15);
            lblInput.TabIndex = 1;
            lblInput.Text = "MIDI Input";
            // 
            // cbMidiInput
            // 
            cbMidiInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMidiInput.FormattingEnabled = true;
            cbMidiInput.Location = new System.Drawing.Point(97, 3);
            cbMidiInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbMidiInput.Name = "cbMidiInput";
            cbMidiInput.Size = new System.Drawing.Size(332, 23);
            cbMidiInput.TabIndex = 0;
            cbMidiInput.SelectedIndexChanged += cbMidiInput_SelectedIndexChanged;
            // 
            // inSettings
            // 
            inSettings.Controls.Add(virtualPiano);
            inSettings.Controls.Add(comboHeap);
            inSettings.Controls.Add(lHeapsizes);
            inSettings.Location = new System.Drawing.Point(4, 24);
            inSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            inSettings.Name = "inSettings";
            inSettings.Size = new System.Drawing.Size(447, 341);
            inSettings.TabIndex = 2;
            inSettings.Text = "Interface";
            inSettings.UseVisualStyleBackColor = true;
            // 
            // virtualPiano
            // 
            virtualPiano.AutoSize = true;
            virtualPiano.Location = new System.Drawing.Point(9, 27);
            virtualPiano.Name = "virtualPiano";
            virtualPiano.Size = new System.Drawing.Size(125, 19);
            virtualPiano.TabIndex = 2;
            virtualPiano.Text = "Show Virtual Piano";
            virtualPiano.UseVisualStyleBackColor = true;
            virtualPiano.CheckedChanged += virtualPiano_CheckedChanged;
            // 
            // comboHeap
            // 
            comboHeap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboHeap.FormattingEnabled = true;
            comboHeap.Items.AddRange(new object[] { "Hexadecimal (0xFF)", "Decimal (255)" });
            comboHeap.Location = new System.Drawing.Point(147, 6);
            comboHeap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboHeap.Name = "comboHeap";
            comboHeap.Size = new System.Drawing.Size(289, 23);
            comboHeap.TabIndex = 1;
            comboHeap.SelectedIndexChanged += comboHeap_SelectedIndexChanged;
            // 
            // lHeapsizes
            // 
            lHeapsizes.AutoSize = true;
            lHeapsizes.Location = new System.Drawing.Point(9, 9);
            lHeapsizes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lHeapsizes.Name = "lHeapsizes";
            lHeapsizes.Size = new System.Drawing.Size(120, 15);
            lHeapsizes.TabIndex = 0;
            lHeapsizes.Text = "Display Heap Sizes in:";
            // 
            // Settings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(455, 412);
            Controls.Add(tabControl1);
            Controls.Add(btnOk);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            ShowIcon = false;
            Text = "Settings";
            Load += Settings_Load;
            tabControl1.ResumeLayout(false);
            saSettings.ResumeLayout(false);
            saSettings.PerformLayout();
            sdSettings.ResumeLayout(false);
            sdSettings.PerformLayout();
            inSettings.ResumeLayout(false);
            inSettings.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lImportTool;
        private System.Windows.Forms.Label lExportTool;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox writeNames;
        private System.Windows.Forms.ComboBox comboImport;
        private System.Windows.Forms.ComboBox comboExport;
        private System.Windows.Forms.TabPage saSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWaveOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.ComboBox cbMidiInput;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage sdSettings;
        private System.Windows.Forms.TabPage inSettings;
        private System.Windows.Forms.ComboBox comboHeap;
        private System.Windows.Forms.Label lHeapsizes;
        private System.Windows.Forms.CheckBox virtualPiano;
    }
}