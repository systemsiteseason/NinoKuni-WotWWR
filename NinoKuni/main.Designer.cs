namespace NinoKuni
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getTableCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opf = new System.Windows.Forms.OpenFileDialog();
            this.panelBox = new System.Windows.Forms.FlowLayoutPanel();
            this.boxTexture = new System.Windows.Forms.PictureBox();
            this.gr1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gr2 = new System.Windows.Forms.GroupBox();
            this.zoomtrack = new System.Windows.Forms.TrackBar();
            this.fName = new System.Windows.Forms.Label();
            this.len = new System.Windows.Forms.Label();
            this.offsetF = new System.Windows.Forms.Label();
            this.typeF = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxTexture)).BeginInit();
            this.gr1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomtrack)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutMeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getTableCharacterToolStripMenuItem});
            this.toolsToolStripMenuItem.Enabled = false;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // getTableCharacterToolStripMenuItem
            // 
            this.getTableCharacterToolStripMenuItem.Name = "getTableCharacterToolStripMenuItem";
            this.getTableCharacterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.getTableCharacterToolStripMenuItem.Text = "Save new file";
            // 
            // aboutMeToolStripMenuItem
            // 
            this.aboutMeToolStripMenuItem.Name = "aboutMeToolStripMenuItem";
            this.aboutMeToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.aboutMeToolStripMenuItem.Text = "AboutMe";
            // 
            // panelBox
            // 
            this.panelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBox.AutoScroll = true;
            this.panelBox.Controls.Add(this.boxTexture);
            this.panelBox.Location = new System.Drawing.Point(226, 27);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(796, 542);
            this.panelBox.TabIndex = 1;
            // 
            // boxTexture
            // 
            this.boxTexture.Location = new System.Drawing.Point(3, 3);
            this.boxTexture.Name = "boxTexture";
            this.boxTexture.Size = new System.Drawing.Size(100, 50);
            this.boxTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.boxTexture.TabIndex = 0;
            this.boxTexture.TabStop = false;
            this.boxTexture.Paint += new System.Windows.Forms.PaintEventHandler(this.boxTexture_Paint);
            // 
            // gr1
            // 
            this.gr1.Controls.Add(this.typeF);
            this.gr1.Controls.Add(this.offsetF);
            this.gr1.Controls.Add(this.len);
            this.gr1.Controls.Add(this.fName);
            this.gr1.Controls.Add(this.label4);
            this.gr1.Controls.Add(this.label3);
            this.gr1.Controls.Add(this.label2);
            this.gr1.Controls.Add(this.label1);
            this.gr1.Location = new System.Drawing.Point(12, 27);
            this.gr1.Name = "gr1";
            this.gr1.Size = new System.Drawing.Size(208, 251);
            this.gr1.TabIndex = 2;
            this.gr1.TabStop = false;
            this.gr1.Text = "Properties";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Offset:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Length:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File name:";
            // 
            // gr2
            // 
            this.gr2.Location = new System.Drawing.Point(12, 284);
            this.gr2.Name = "gr2";
            this.gr2.Size = new System.Drawing.Size(208, 285);
            this.gr2.TabIndex = 3;
            this.gr2.TabStop = false;
            this.gr2.Text = "Data";
            // 
            // zoomtrack
            // 
            this.zoomtrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomtrack.Enabled = false;
            this.zoomtrack.Location = new System.Drawing.Point(682, 0);
            this.zoomtrack.Maximum = 500;
            this.zoomtrack.Name = "zoomtrack";
            this.zoomtrack.Size = new System.Drawing.Size(338, 45);
            this.zoomtrack.TabIndex = 4;
            this.zoomtrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.zoomtrack.Scroll += new System.EventHandler(this.zoomtrack_Scroll);
            // 
            // fName
            // 
            this.fName.AutoSize = true;
            this.fName.Location = new System.Drawing.Point(79, 24);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(0, 13);
            this.fName.TabIndex = 4;
            // 
            // len
            // 
            this.len.AutoSize = true;
            this.len.Location = new System.Drawing.Point(79, 43);
            this.len.Name = "len";
            this.len.Size = new System.Drawing.Size(0, 13);
            this.len.TabIndex = 5;
            // 
            // offsetF
            // 
            this.offsetF.AutoSize = true;
            this.offsetF.Location = new System.Drawing.Point(79, 61);
            this.offsetF.Name = "offsetF";
            this.offsetF.Size = new System.Drawing.Size(0, 13);
            this.offsetF.TabIndex = 6;
            // 
            // typeF
            // 
            this.typeF.AutoSize = true;
            this.typeF.Location = new System.Drawing.Point(79, 77);
            this.typeF.Name = "typeF";
            this.typeF.Size = new System.Drawing.Size(0, 13);
            this.typeF.TabIndex = 7;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 581);
            this.Controls.Add(this.gr2);
            this.Controls.Add(this.gr1);
            this.Controls.Add(this.panelBox);
            this.Controls.Add(this.zoomtrack);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ni no Kuni Wrath of the White Witch Remastered Texture Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelBox.ResumeLayout(false);
            this.panelBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxTexture)).EndInit();
            this.gr1.ResumeLayout(false);
            this.gr1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomtrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getTableCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.FlowLayoutPanel panelBox;
        private System.Windows.Forms.PictureBox boxTexture;
        private System.Windows.Forms.GroupBox gr1;
        private System.Windows.Forms.GroupBox gr2;
        private System.Windows.Forms.TrackBar zoomtrack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label typeF;
        private System.Windows.Forms.Label offsetF;
        private System.Windows.Forms.Label len;
        private System.Windows.Forms.Label fName;
    }
}

