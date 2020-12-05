using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinoKuni
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            this.MinimumSize = new Size(600, 400);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opf.Filter = "All file(*.*)|*.cfg.bin;*.p3igg;*.p3img;*.imgpak|All Font or Table Chars|*.cfg.bin|Header Texture|*.p3img|Texture|*.p3igg|Packet Texture|*.imgpak";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(opf.FileName))
                {
                    if(Path.GetExtension(opf.FileName) == ".cfg.bin")
                    {

                    }
                    else if(Path.GetExtension(opf.FileName) == ".p3img")
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
