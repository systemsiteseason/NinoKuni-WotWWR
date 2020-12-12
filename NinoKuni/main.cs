using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pfim;

namespace NinoKuni
{
    public partial class main : Form
    {

        private static GCHandle handle;
        Image imgOriginal;

        Dictionary<byte[], long[]> dic = new Dictionary<byte[], long[]>();

        Rectangle rect;

        Point LocationXlYt = new Point(409, 78);
        Point LocationXrYb = new Point(436, 156);

        public byte[] all = null;
        public byte[] somecolor = null;

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
            opf.Filter = "All file(*.*)|*.p3img;*.imgpak|Header Texture|*.p3img|Packet Texture|*.imgpak";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(opf.FileName))
                {
                    string path = Path.GetDirectoryName(opf.FileName);
                    string filename = Path.GetFileNameWithoutExtension(opf.FileName);
                    if(Path.GetExtension(opf.FileName) == ".p3img")
                    {
                        fName.Text = Path.GetFileName(opf.FileName);
                        var rdimg = new BinaryReader(new FileStream(opf.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                        BinaryReader rdigg = null;
                        BinaryReader rdcfg = null;
                        bool cfg = false;
                        bool igg = false;
                        if (File.Exists(path + "\\" + filename + ".p3igg"))
                        {
                            rdigg = new BinaryReader(new FileStream(path + "\\" + filename + ".p3igg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                            igg = true;
                        }

                        if (File.Exists(path + "\\" + filename + ".cfg.bin"))
                        {
                            rdcfg = new BinaryReader(new FileStream(path + "\\" + filename + ".cfg.bin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                            cfg = true;
                        }

                        if (igg)
                        {
                            rdimg.BaseStream.Seek(184, SeekOrigin.Begin);
                            byte[] head = new byte[] { 0x44, 0x44, 0x53, 0x20, 0x7C, 0x00, 0x00, 0x00, 0x07, 0x10, 0x00, 0x00 };
                            int width = rdimg.ReadInt16();
                            int height = rdimg.ReadInt16();
                            byte[] data_raw = rdigg.ReadBytes((int)rdigg.BaseStream.Length);
                            len.Text = "0x" + data_raw.Length.ToString("X");
                            offsetF.Text = "0x0";
                            if (width * height * 4 == data_raw.Length)
                            {
                                typeF.Text = "Texture (RGBA8)";
                                IsRGBA();
                                byte[] done = new byte[head.Length + 12 + argb.Length + data_raw.Length];
                                Buffer.BlockCopy(head, 0, done, 0, head.Length);
                                Buffer.BlockCopy(BitConverter.GetBytes(height), 0, done, head.Length, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(width), 0, done, head.Length + 4, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(data_raw.Length), 0, done, head.Length + 8, 4);
                                Buffer.BlockCopy(argb, 0, done, head.Length + 12, argb.Length);
                                Buffer.BlockCopy(data_raw, 0, done, head.Length + 12 + argb.Length, data_raw.Length);
                                all = done;
                                TexDDS(done);
                            }
                            else
                            {
                                typeF.Text = "Texture (BC7)";
                                NotRGBA();
                                byte[] done = new byte[head.Length + 12 + bc7.Length + data_raw.Length];
                                Buffer.BlockCopy(head, 0, done, 0, head.Length);
                                Buffer.BlockCopy(BitConverter.GetBytes(height), 0, done, head.Length, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(width), 0, done, head.Length + 4, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(data_raw.Length), 0, done, head.Length + 8, 4);
                                Buffer.BlockCopy(bc7, 0, done, head.Length + 12, bc7.Length);
                                Buffer.BlockCopy(data_raw, 0, done, head.Length + 12 + bc7.Length, data_raw.Length);
                                all = done;
                                TexDDS(done);
                            }

                        }
                        else
                        {
                            MessageBox.Show("No p3igg file found!");
                        }

                        if (cfg)
                        {
                            WithMap();
                            rdcfg.BaseStream.Seek(32, SeekOrigin.Begin);
                            long count = rdcfg.ReadInt64();
                            rdcfg.ReadInt64(); //width
                            rdcfg.ReadInt64();//height
                            rdcfg.ReadInt64();//file_cound
                            for(int i = 0; i < count; i++)
                            {
                                long[] lsInf = new long[5];
                                rdcfg.ReadBytes(16);//sth
                                byte[] id = rdcfg.ReadBytes(8);
                                lsInf[0] = rdcfg.ReadInt64();//block_x
                                lsInf[1] = rdcfg.ReadInt64();//block_y
                                lsInf[2] = rdcfg.ReadInt64();//width
                                lsInf[3] = rdcfg.ReadInt64();//adv_left
                                lsInf[4] = rdcfg.ReadInt64();//adv_right
                                rdcfg.ReadInt64();
                                dic.Add(id, lsInf);
                            }
                            foreach (var pair in dic)
                            {
                                byte[] showchar = Decore(pair.Key);
                                Array.Reverse(showchar);
                                listID.Items.Add(Encoding.UTF8.GetString(showchar));
                            }
                        }
                        else
                        {
                            NoneMap();
                        }
                        
                    }
                    else if(Path.GetExtension(opf.FileName) == ".imgpak")
                    {

                    }
                    else
                    {

                    }

                }
            }
        }

        private byte[] Decore(byte[] input)
        {
            var i = input.Length - 1;
            while(input[i] == 0)
            {
                --i;
            }
            var output = new byte[i + 1];
            Array.Copy(input, output, i + 1);
            return output;
        }

        public void TexDDS(byte[] data)
        {
            var image = Pfim.Pfim.FromStream(new MemoryStream(data));

            PixelFormat format;
            switch (image.Format)
            {
                case Pfim.ImageFormat.Rgb24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case Pfim.ImageFormat.Rgba32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                case Pfim.ImageFormat.R5g5b5:
                    format = PixelFormat.Format16bppRgb555;
                    break;

                case Pfim.ImageFormat.R5g6b5:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case Pfim.ImageFormat.R5g5b5a1:
                    format = PixelFormat.Format16bppArgb1555;
                    break;

                case Pfim.ImageFormat.Rgb8:
                    format = PixelFormat.Format8bppIndexed;
                    break;

                default:
                    var msg = $"{image.Format} is not recognized for Bitmap on Windows Forms. " +
                               "You'd need to write a conversion function to convert the data to known format";
                    var caption = "Unrecognized format";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK);
                    return;
            }
            if (handle.IsAllocated)
            {
                handle.Free();
            }

            handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
            var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);
            var bitmap = new Bitmap(image.Width, image.Height, image.Stride, format, ptr);

            if (format == PixelFormat.Format8bppIndexed)
            {
                var palette = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    palette.Entries[i] = Color.FromArgb((byte)i, (byte)i, (byte)i);
                }
                bitmap.Palette = palette;
            }

            boxTexture.Image = bitmap;
            imgOriginal = boxTexture.Image;
        }

        private void zoomtrack_Scroll(object sender, EventArgs e)
        {
            if (zoomtrack.Value > 0)
            {
                boxTexture.Image = Zoom(imgOriginal, new Size(zoomtrack.Value, zoomtrack.Value));
            }
        }

        Image Zoom(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(img, img.Width + (img.Width * size.Width / 100), img.Height + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        public byte[] argb = new byte[]
        {
            0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x20, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0x00,
            0x00, 0x00, 0x00, 0xFF, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        public byte[] bc7 = new byte[]
        {
            0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x44, 0x58, 0x31, 0x30,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x62, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        private void boxTexture_Paint(object sender, PaintEventArgs e)
        {
            if(rect != null)
            {
                e.Graphics.DrawRectangle(Pens.White, GetRect());
                //e.Graphics.DrawLine(P)
            }
        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();
            rect.X = Math.Min(LocationXlYt.X, LocationXrYb.X);
            rect.Y = Math.Min(LocationXlYt.Y, LocationXrYb.Y);
            rect.Width = Math.Abs(LocationXlYt.X - LocationXrYb.X);
            rect.Height = Math.Abs(LocationXlYt.Y - LocationXrYb.Y);
            return rect;
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sol\n\nDiscord: https://discord.gg/GVQnYb6c5X", "About!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private byte[] ResRGBA(bool R, bool G, bool B, bool A, byte[] data)
        {
            byte[] buffer = new byte[data.Length];
            Buffer.BlockCopy(data, 0, buffer, 0, data.Length);
            BinaryWriter wtms = new BinaryWriter(new MemoryStream(buffer));
            wtms.BaseStream.Seek(128, SeekOrigin.Begin);
            for(int i = 0; i < (buffer.Length - 128)/4; i++)
            {
                if (R)
                    wtms.BaseStream.Seek(1, SeekOrigin.Current);
                else
                    wtms.Write((byte)0);

                if (G)
                    wtms.BaseStream.Seek(1, SeekOrigin.Current);
                else
                    wtms.Write((byte)0);

                if (B)
                    wtms.BaseStream.Seek(1, SeekOrigin.Current);
                else
                    wtms.Write((byte)0);

                if (A)
                    wtms.BaseStream.Seek(1, SeekOrigin.Current);
                else
                    wtms.Write((byte)0xFF);
            }
            somecolor = buffer;
            return buffer;
        }

        public void RGBChange()
        {
            if (ckR.Checked && ckG.Checked && ckB.Checked && ckA.Checked)
            {
                TexDDS(all);
            }
            else if ((!ckR.Checked && !ckG.Checked && !ckB.Checked && ckA.Checked) || (!ckR.Checked && !ckG.Checked && !ckB.Checked && !ckA.Checked))
            {
                MessageBox.Show("Please checked R or G or B channel, no data result!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TexDDS(ResRGBA(ckR.Checked, ckG.Checked, ckB.Checked, ckA.Checked, all));
            }
        }

        #region RGBchange

        private void ckR_CheckedChanged(object sender, EventArgs e)
        {
            RGBChange();
        }

        private void ckG_CheckedChanged(object sender, EventArgs e)
        {
            RGBChange();
        }

        private void ckB_CheckedChanged(object sender, EventArgs e)
        {
            RGBChange();
        }

        private void ckA_CheckedChanged(object sender, EventArgs e)
        {
            RGBChange();
        }

        #endregion

        #region Texture

        private void btnExtexture_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "DirectDraw Surface|*.dds";
            save.FileName = fName.Text;
            if(save.ShowDialog() == DialogResult.OK)
            {
                if (ckR.Checked && ckG.Checked && ckB.Checked && ckA.Checked)
                {
                    BinaryWriter wt = new BinaryWriter(File.Create(save.FileName));
                    wt.Write(all);
                    wt.Close();
                }
                else
                {
                    BinaryWriter wt = new BinaryWriter(File.Create(save.FileName));
                    wt.Write(somecolor);
                    wt.Close();
                }
            }
        }

        private void btnLdtexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadF = new OpenFileDialog();
            loadF.Filter = "DirectDraw Surface|*.dds";
            if (loadF.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(loadF.FileName))
                {
                    all = File.ReadAllBytes(loadF.FileName);
                    TexDDS(all);
                }
            }
        }

        #endregion

        #region ControlUI

        private void IsRGBA()
        {
            ckA.Enabled = true;
            ckR.Enabled = true;
            ckG.Enabled = true;
            ckB.Enabled = true;
        }

        private void NotRGBA()
        {
            ckA.Enabled = false;
            ckR.Enabled = false;
            ckG.Enabled = false;
            ckB.Enabled = false;
        }

        private void NoneMap()
        {
            btnExtexture.Enabled = true;
            btnLdtexture.Enabled = true;
            //mapping
            btnExmapping.Enabled = false;
            btnLdmapping.Enabled = false;
            btnUpdate.Enabled = false;
            idBox.Enabled = false;
            xBox.Enabled = false;
            yBox.Enabled = false;
            wBox.Enabled = false;
            lBox.Enabled = false;
            rBox.Enabled = false;
            idBox.Text = "n/a";
            xBox.Text = "0";
            yBox.Text = "0";
            wBox.Text = "0";
            lBox.Text = "0";
            rBox.Text = "0";
            listID.Enabled = false;
            listID.Items.Clear();
        }

        private void WithMap()
        {
            btnExtexture.Enabled = true;
            btnLdtexture.Enabled = true;
            //mapping
            btnExmapping.Enabled = true;
            btnLdmapping.Enabled = true;
            btnUpdate.Enabled = true;
            idBox.Enabled = true;
            xBox.Enabled = true;
            yBox.Enabled = true;
            wBox.Enabled = true;
            lBox.Enabled = true;
            rBox.Enabled = true;
            listID.Enabled = true;
            listID.Items.Clear();
        }

        #endregion

        private void listID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listID.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                long[] result_data = dic.Values.ElementAt(index);
                idBox.Text = listID.Items[index].ToString();
                xBox.Text = result_data[0].ToString();
                yBox.Text = result_data[1].ToString();
                wBox.Text = result_data[2].ToString();
                lBox.Text = result_data[3].ToString();
                rBox.Text = result_data[4].ToString();
            }
        }
    }
}
