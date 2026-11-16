namespace NitroStudio2.Dialogs
{
    partial class Help
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            helpDocument = new System.Windows.Forms.RichTextBox();
            pageList = new System.Windows.Forms.TreeView();
            imageList1 = new System.Windows.Forms.ImageList(components);
            SuspendLayout();
            // 
            // helpDocument
            // 
            helpDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            helpDocument.Location = new System.Drawing.Point(271, 0);
            helpDocument.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            helpDocument.Name = "helpDocument";
            helpDocument.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            helpDocument.Size = new System.Drawing.Size(635, 533);
            helpDocument.TabIndex = 0;
            helpDocument.Text = "";
            helpDocument.LinkClicked += helpDocument_LinkClicked;
            // 
            // pageList
            // 
            pageList.Dock = System.Windows.Forms.DockStyle.Left;
            pageList.ImageIndex = 1;
            pageList.ImageList = imageList1;
            pageList.Location = new System.Drawing.Point(0, 0);
            pageList.Name = "pageList";
            pageList.SelectedImageIndex = 1;
            pageList.ShowLines = false;
            pageList.Size = new System.Drawing.Size(271, 533);
            pageList.TabIndex = 1;
            pageList.AfterSelect += pageList_AfterSelect;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            imageList1.Images.SetKeyName(0, "blank.png");
            imageList1.Images.SetKeyName(1, "FILES.png");
            imageList1.Images.SetKeyName(2, "blank.png");
            // 
            // Help
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(906, 533);
            Controls.Add(helpDocument);
            Controls.Add(pageList);
            Name = "Help";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Help";
            Load += Help_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox helpDocument;
        private System.Windows.Forms.TreeView pageList;
        private System.Windows.Forms.ImageList imageList1;
    }
}