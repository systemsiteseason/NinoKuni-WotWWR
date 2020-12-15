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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lBox = new System.Windows.Forms.TextBox();
            this.xBox = new System.Windows.Forms.TextBox();
            this.wBox = new System.Windows.Forms.TextBox();
            this.yBox = new System.Windows.Forms.TextBox();
            this.rBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.btnLdtexture = new System.Windows.Forms.Button();
            this.btnLdmapping = new System.Windows.Forms.Button();
            this.btnExtexture = new System.Windows.Forms.Button();
            this.btnExmapping = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.listID = new System.Windows.Forms.ListBox();
            this.ckA = new System.Windows.Forms.CheckBox();
            this.ckG = new System.Windows.Forms.CheckBox();
            this.ckB = new System.Windows.Forms.CheckBox();
            this.ckR = new System.Windows.Forms.CheckBox();
            this.typeF = new System.Windows.Forms.Label();
            this.offsetF = new System.Windows.Forms.Label();
            this.len = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gr2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.zoomtrack = new System.Windows.Forms.TrackBar();
            this.ckhA = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxTexture)).BeginInit();
            this.gr1.SuspendLayout();
            this.gr2.SuspendLayout();
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
            this.getTableCharacterToolStripMenuItem.Text = "Save Archives";
            this.getTableCharacterToolStripMenuItem.Click += new System.EventHandler(this.getTableCharacterToolStripMenuItem_Click);
            // 
            // aboutMeToolStripMenuItem
            // 
            this.aboutMeToolStripMenuItem.Name = "aboutMeToolStripMenuItem";
            this.aboutMeToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.aboutMeToolStripMenuItem.Text = "AboutMe";
            this.aboutMeToolStripMenuItem.Click += new System.EventHandler(this.aboutMeToolStripMenuItem_Click);
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
            this.gr1.Controls.Add(this.ckhA);
            this.gr1.Controls.Add(this.label10);
            this.gr1.Controls.Add(this.label9);
            this.gr1.Controls.Add(this.label8);
            this.gr1.Controls.Add(this.label7);
            this.gr1.Controls.Add(this.label6);
            this.gr1.Controls.Add(this.label5);
            this.gr1.Controls.Add(this.lBox);
            this.gr1.Controls.Add(this.xBox);
            this.gr1.Controls.Add(this.wBox);
            this.gr1.Controls.Add(this.yBox);
            this.gr1.Controls.Add(this.rBox);
            this.gr1.Controls.Add(this.idBox);
            this.gr1.Controls.Add(this.btnLdtexture);
            this.gr1.Controls.Add(this.btnLdmapping);
            this.gr1.Controls.Add(this.btnExtexture);
            this.gr1.Controls.Add(this.btnExmapping);
            this.gr1.Controls.Add(this.btnUpdate);
            this.gr1.Controls.Add(this.listID);
            this.gr1.Controls.Add(this.ckA);
            this.gr1.Controls.Add(this.ckG);
            this.gr1.Controls.Add(this.ckB);
            this.gr1.Controls.Add(this.ckR);
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
            this.gr1.Size = new System.Drawing.Size(208, 315);
            this.gr1.TabIndex = 2;
            this.gr1.TabStop = false;
            this.gr1.Text = "Properties";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(150, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "R";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "L";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "W";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "ID";
            // 
            // lBox
            // 
            this.lBox.Enabled = false;
            this.lBox.Location = new System.Drawing.Point(171, 156);
            this.lBox.Name = "lBox";
            this.lBox.Size = new System.Drawing.Size(27, 20);
            this.lBox.TabIndex = 25;
            this.lBox.Text = "0";
            this.lBox.TextChanged += new System.EventHandler(this.xBox_TextChanged);
            this.lBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xBox_KeyPress);
            // 
            // xBox
            // 
            this.xBox.Enabled = false;
            this.xBox.Location = new System.Drawing.Point(107, 156);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(26, 20);
            this.xBox.TabIndex = 24;
            this.xBox.Text = "0";
            this.xBox.TextChanged += new System.EventHandler(this.xBox_TextChanged);
            this.xBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xBox_KeyPress);
            // 
            // wBox
            // 
            this.wBox.Enabled = false;
            this.wBox.Location = new System.Drawing.Point(171, 130);
            this.wBox.Name = "wBox";
            this.wBox.Size = new System.Drawing.Size(27, 20);
            this.wBox.TabIndex = 23;
            this.wBox.Text = "0";
            this.wBox.TextChanged += new System.EventHandler(this.xBox_TextChanged);
            this.wBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xBox_KeyPress);
            // 
            // yBox
            // 
            this.yBox.Enabled = false;
            this.yBox.Location = new System.Drawing.Point(107, 182);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(26, 20);
            this.yBox.TabIndex = 22;
            this.yBox.Text = "0";
            this.yBox.TextChanged += new System.EventHandler(this.xBox_TextChanged);
            this.yBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xBox_KeyPress);
            // 
            // rBox
            // 
            this.rBox.Enabled = false;
            this.rBox.Location = new System.Drawing.Point(171, 182);
            this.rBox.Name = "rBox";
            this.rBox.Size = new System.Drawing.Size(27, 20);
            this.rBox.TabIndex = 21;
            this.rBox.Text = "0";
            this.rBox.TextChanged += new System.EventHandler(this.xBox_TextChanged);
            this.rBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.xBox_KeyPress);
            // 
            // idBox
            // 
            this.idBox.Enabled = false;
            this.idBox.Location = new System.Drawing.Point(107, 130);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(26, 20);
            this.idBox.TabIndex = 20;
            this.idBox.Text = "n/a";
            // 
            // btnLdtexture
            // 
            this.btnLdtexture.Enabled = false;
            this.btnLdtexture.Location = new System.Drawing.Point(108, 286);
            this.btnLdtexture.Name = "btnLdtexture";
            this.btnLdtexture.Size = new System.Drawing.Size(94, 23);
            this.btnLdtexture.TabIndex = 19;
            this.btnLdtexture.Text = "Load Texture";
            this.btnLdtexture.UseVisualStyleBackColor = true;
            this.btnLdtexture.Click += new System.EventHandler(this.btnLdtexture_Click);
            // 
            // btnLdmapping
            // 
            this.btnLdmapping.Enabled = false;
            this.btnLdmapping.Location = new System.Drawing.Point(9, 286);
            this.btnLdmapping.Name = "btnLdmapping";
            this.btnLdmapping.Size = new System.Drawing.Size(94, 23);
            this.btnLdmapping.TabIndex = 18;
            this.btnLdmapping.Text = "Load Mapping";
            this.btnLdmapping.UseVisualStyleBackColor = true;
            this.btnLdmapping.Click += new System.EventHandler(this.btnLdmapping_Click);
            // 
            // btnExtexture
            // 
            this.btnExtexture.Enabled = false;
            this.btnExtexture.Location = new System.Drawing.Point(108, 257);
            this.btnExtexture.Name = "btnExtexture";
            this.btnExtexture.Size = new System.Drawing.Size(94, 23);
            this.btnExtexture.TabIndex = 17;
            this.btnExtexture.Text = "Export Texture";
            this.btnExtexture.UseVisualStyleBackColor = true;
            this.btnExtexture.Click += new System.EventHandler(this.btnExtexture_Click);
            // 
            // btnExmapping
            // 
            this.btnExmapping.Enabled = false;
            this.btnExmapping.Location = new System.Drawing.Point(9, 258);
            this.btnExmapping.Name = "btnExmapping";
            this.btnExmapping.Size = new System.Drawing.Size(93, 23);
            this.btnExmapping.TabIndex = 16;
            this.btnExmapping.Text = "Export Mapping";
            this.btnExmapping.UseVisualStyleBackColor = true;
            this.btnExmapping.Click += new System.EventHandler(this.btnExmapping_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(123, 210);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(58, 22);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // listID
            // 
            this.listID.Enabled = false;
            this.listID.FormattingEnabled = true;
            this.listID.Location = new System.Drawing.Point(9, 131);
            this.listID.Name = "listID";
            this.listID.Size = new System.Drawing.Size(61, 121);
            this.listID.TabIndex = 12;
            this.listID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listID_MouseClick);
            // 
            // ckA
            // 
            this.ckA.AutoSize = true;
            this.ckA.Checked = true;
            this.ckA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckA.Enabled = false;
            this.ckA.Location = new System.Drawing.Point(127, 101);
            this.ckA.Name = "ckA";
            this.ckA.Size = new System.Drawing.Size(33, 17);
            this.ckA.TabIndex = 11;
            this.ckA.Text = "A";
            this.ckA.UseVisualStyleBackColor = true;
            this.ckA.CheckedChanged += new System.EventHandler(this.ckR_CheckedChanged);
            // 
            // ckG
            // 
            this.ckG.AutoSize = true;
            this.ckG.Checked = true;
            this.ckG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckG.Enabled = false;
            this.ckG.Location = new System.Drawing.Point(48, 101);
            this.ckG.Name = "ckG";
            this.ckG.Size = new System.Drawing.Size(34, 17);
            this.ckG.TabIndex = 10;
            this.ckG.Text = "G";
            this.ckG.UseVisualStyleBackColor = true;
            this.ckG.CheckedChanged += new System.EventHandler(this.ckR_CheckedChanged);
            // 
            // ckB
            // 
            this.ckB.AutoSize = true;
            this.ckB.Checked = true;
            this.ckB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckB.Enabled = false;
            this.ckB.Location = new System.Drawing.Point(88, 101);
            this.ckB.Name = "ckB";
            this.ckB.Size = new System.Drawing.Size(33, 17);
            this.ckB.TabIndex = 9;
            this.ckB.Text = "B";
            this.ckB.UseVisualStyleBackColor = true;
            this.ckB.CheckedChanged += new System.EventHandler(this.ckR_CheckedChanged);
            // 
            // ckR
            // 
            this.ckR.AutoSize = true;
            this.ckR.Checked = true;
            this.ckR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckR.Enabled = false;
            this.ckR.Location = new System.Drawing.Point(9, 101);
            this.ckR.Name = "ckR";
            this.ckR.Size = new System.Drawing.Size(34, 17);
            this.ckR.TabIndex = 8;
            this.ckR.Text = "R";
            this.ckR.UseVisualStyleBackColor = true;
            this.ckR.CheckedChanged += new System.EventHandler(this.ckR_CheckedChanged);
            // 
            // typeF
            // 
            this.typeF.AutoSize = true;
            this.typeF.Location = new System.Drawing.Point(79, 77);
            this.typeF.Name = "typeF";
            this.typeF.Size = new System.Drawing.Size(0, 13);
            this.typeF.TabIndex = 7;
            // 
            // offsetF
            // 
            this.offsetF.AutoSize = true;
            this.offsetF.Location = new System.Drawing.Point(79, 61);
            this.offsetF.Name = "offsetF";
            this.offsetF.Size = new System.Drawing.Size(0, 13);
            this.offsetF.TabIndex = 6;
            // 
            // len
            // 
            this.len.AutoSize = true;
            this.len.Location = new System.Drawing.Point(79, 43);
            this.len.Name = "len";
            this.len.Size = new System.Drawing.Size(0, 13);
            this.len.TabIndex = 5;
            // 
            // fName
            // 
            this.fName.AutoSize = true;
            this.fName.Location = new System.Drawing.Point(79, 24);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(0, 13);
            this.fName.TabIndex = 4;
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
            this.gr2.Controls.Add(this.treeView1);
            this.gr2.Location = new System.Drawing.Point(12, 348);
            this.gr2.Name = "gr2";
            this.gr2.Size = new System.Drawing.Size(208, 221);
            this.gr2.TabIndex = 3;
            this.gr2.TabStop = false;
            this.gr2.Text = "Data";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(5, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(197, 196);
            this.treeView1.TabIndex = 0;
            // 
            // zoomtrack
            // 
            this.zoomtrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomtrack.Enabled = false;
            this.zoomtrack.Location = new System.Drawing.Point(682, 0);
            this.zoomtrack.Maximum = 200;
            this.zoomtrack.Name = "zoomtrack";
            this.zoomtrack.Size = new System.Drawing.Size(338, 45);
            this.zoomtrack.TabIndex = 4;
            this.zoomtrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.zoomtrack.Scroll += new System.EventHandler(this.zoomtrack_Scroll);
            // 
            // ckhA
            // 
            this.ckhA.AutoSize = true;
            this.ckhA.Enabled = false;
            this.ckhA.Location = new System.Drawing.Point(166, 101);
            this.ckhA.Name = "ckhA";
            this.ckhA.Size = new System.Drawing.Size(39, 17);
            this.ckhA.TabIndex = 32;
            this.ckhA.Text = "hA";
            this.ckhA.UseVisualStyleBackColor = true;
            this.ckhA.CheckedChanged += new System.EventHandler(this.ckR_CheckedChanged);
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
            this.gr2.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox listID;
        private System.Windows.Forms.CheckBox ckA;
        private System.Windows.Forms.CheckBox ckG;
        private System.Windows.Forms.CheckBox ckB;
        private System.Windows.Forms.CheckBox ckR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lBox;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.TextBox wBox;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox rBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Button btnLdtexture;
        private System.Windows.Forms.Button btnLdmapping;
        private System.Windows.Forms.Button btnExtexture;
        private System.Windows.Forms.Button btnExmapping;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckhA;
    }
}

