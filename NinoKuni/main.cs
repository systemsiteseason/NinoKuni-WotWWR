using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pfim;

namespace NinoKuni
{
    public partial class main : Form
    {
        float zoom = 1f;
        private static GCHandle handle;
        Image imgOriginal;

        Dictionary<byte[], long[]> dic = new Dictionary<byte[], long[]>();

        Rectangle rect;

        Point LocationXlYt;
        Point LocationXrYb;
        Point AdvXY_L;
        Point AdvX1Y1_L;
        Point AdvXY_R;
        Point AdvX1Y1_R;

        public byte[] all = null;
        public byte[] somecolor = null;

        public bool cfg = false;
        public bool igg = false;

        string path = null;
        string filename = null;

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
                    path = Path.GetDirectoryName(opf.FileName);
                    filename = Path.GetFileNameWithoutExtension(opf.FileName);
                    if(Path.GetExtension(opf.FileName) == ".p3img")
                    {
                        fName.Text = Path.GetFileName(opf.FileName);
                        var rdimg = new BinaryReader(new FileStream(opf.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                        BinaryReader rdigg = null;
                        BinaryReader rdcfg = null;
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
                            toolsToolStripMenuItem.Enabled = true;
                            rdimg.BaseStream.Seek(184, SeekOrigin.Begin);
                            byte[] head = new byte[] { 0x44, 0x44, 0x53, 0x20, 0x7C, 0x00, 0x00, 0x00, 0x07, 0x10, 0x00, 0x00 };
                            int width = rdimg.ReadInt16();
                            int height = rdimg.ReadInt16();
                            byte[] data_raw = rdigg.ReadBytes((int)rdigg.BaseStream.Length);
                            len.Text = "0x" + data_raw.Length.ToString("X");
                            offsetF.Text = "0x0";
                            zoomtrack.Value = 0;
                            zoom = 1f;
                            zoomtrack.Enabled = true;
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
                            toolsToolStripMenuItem.Enabled = false;
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
                                long[] lsInf = new long[6];
                                rdcfg.ReadBytes(16);//sth
                                byte[] id = rdcfg.ReadBytes(8);
                                lsInf[0] = rdcfg.ReadInt64();//block_x
                                lsInf[1] = rdcfg.ReadInt64();//block_y
                                lsInf[2] = rdcfg.ReadInt64();//width
                                lsInf[3] = rdcfg.ReadInt64();//adv_left
                                lsInf[4] = rdcfg.ReadInt64();//adv_right
                                lsInf[5] = BitConverter.ToInt64(id, 0);
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
            boxTexture.Image = Zoom(imgOriginal, new Size(zoomtrack.Value, zoomtrack.Value));
            zoom = 1f + zoomtrack.Value / 100f;
            boxTexture.Invalidate();
            GC.Collect();
            GC.WaitForPendingFinalizers();
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
            e.Graphics.ScaleTransform(zoom, zoom);
            if(rect != null)
            {
                e.Graphics.DrawRectangle(Pens.White, GetRect());//w and h
                e.Graphics.DrawLine(Pens.Green, AdvXY_L, AdvX1Y1_L);// left
                e.Graphics.DrawLine(Pens.Blue, AdvXY_R, AdvX1Y1_R);// right
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

        private byte[] ResRGBA(bool R, bool G, bool B, bool A, bool hA, byte[] data)
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
                {
                    if(hA)
                        wtms.Write((byte)0x00);
                    else
                        wtms.Write((byte)0xFF);
                }
            }
            somecolor = buffer;
            return buffer;
        }

        public void RGBChange()
        {
            if (ckR.Checked && ckG.Checked && ckB.Checked && ckA.Checked)
            {
                zoom = 1f;
                TexDDS(all);
            }
            else if (!ckR.Checked && !ckG.Checked && !ckB.Checked && !ckA.Checked)
            {
                MessageBox.Show("Please checked R or G or B channel, no data result!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                zoom = 1f;
                TexDDS(ResRGBA(ckR.Checked, ckG.Checked, ckB.Checked, ckA.Checked, ckhA.Checked, all));
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #region RGBchange

        private void ckR_CheckedChanged(object sender, EventArgs e)
        {
            RGBChange();
        }

        #endregion

        #region Texture

        private void btnExtexture_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "DirectDraw Surface|*.dds";
            save.FileName = fName.Text + ".dds";
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
            ckhA.Enabled = true;
            ckA.Checked = true;
            ckR.Checked = true;
            ckG.Checked = true;
            ckB.Checked = true;
            ckhA.Checked = false;
        }

        private void NotRGBA()
        {
            ckA.Enabled = false;
            ckR.Enabled = false;
            ckG.Enabled = false;
            ckB.Enabled = false;
            ckhA.Enabled = false;
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
            dic.Clear();
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
            idBox.Text = "n/a";
            xBox.Text = "0";
            yBox.Text = "0";
            wBox.Text = "0";
            lBox.Text = "0";
            rBox.Text = "0";
            listID.Enabled = true;
            listID.Items.Clear();
            dic.Clear();
        }

        #endregion

        public void RenderMap(long Xl, long Yt, long Xr, long Yb)
        {
            LocationXlYt = new Point((int)Xl, (int)Yt);
            LocationXrYb = new Point((int)Xr, (int)Yb + 78);
            AdvXY_L = new Point((int)Xl - (int)long.Parse(lBox.Text), (int)Yt);
            AdvX1Y1_L = new Point((int)Xl - (int)long.Parse(lBox.Text), (int)Yt + 95);
            AdvXY_R = new Point((int)Xl + (int)long.Parse(rBox.Text), (int)Yt);
            AdvX1Y1_R = new Point((int)Xl + (int)long.Parse(rBox.Text), (int)Yt + 95);
            Refresh();
        }

        private void xBox_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(xBox.Text) && !string.IsNullOrEmpty(yBox.Text) && !string.IsNullOrEmpty(wBox.Text) && !string.IsNullOrEmpty(lBox.Text) && !string.IsNullOrEmpty(rBox.Text))
            {
                RenderMap(long.Parse(xBox.Text), long.Parse(yBox.Text), long.Parse(xBox.Text) + long.Parse(wBox.Text), long.Parse(yBox.Text));
            }
        }

        private void btnExmapping_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text File|*.txt";
            sv.FileName = fName.Text + ".txt";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wtmap = new StreamWriter(sv.FileName);
                wtmap.WriteLine("var=0");
                string ch = "";
                foreach (var pair in dic)
                {
                    byte[] showchar = Decore(pair.Key);
                    Array.Reverse(showchar);
                    string character = Encoding.UTF8.GetString(showchar);
                    long[] allp = pair.Value;
                    ch += character;
                    wtmap.WriteLine("id=" + Convert.ToInt32(character[0])+ " x=" + allp[0] + " y=" + allp[1] + " width="+allp[2] + " padding_left=" + allp[3] + " padding_right=" + allp[4]);
                }
                wtmap.WriteLine("var=" + ch);
                wtmap.Close();
            }
        }

        private void btnLdmapping_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadF = new OpenFileDialog();
            loadF.Filter = "Text FIle|*.txt";
            if (loadF.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(loadF.FileName))
                {
                    string[] lines = File.ReadAllLines(loadF.FileName);
                    dic.Clear();
                    listID.Items.Clear();
                    foreach(string line in lines)
                    {
                        if(line != "var=0")
                        {
                            var data = line.Split(' ');
                            long[] input = new long[6];
                            byte[] charint = new byte[8];
                            byte[] clog = Encoding.UTF8.GetBytes(Convert.ToChar(int.Parse(data[0].Split('=')[1])).ToString());
                            Array.Reverse(clog);
                            Buffer.BlockCopy(clog, 0, charint, 0, clog.Length);
                            input[0] = long.Parse(data[1].Split('=')[1]);
                            input[1] = long.Parse(data[2].Split('=')[1]);
                            input[2] = long.Parse(data[3].Split('=')[1]);
                            input[3] = long.Parse(data[4].Split('=')[1]);
                            input[4] = long.Parse(data[5].Split('=')[1]);
                            input[5] = BitConverter.ToInt64(charint, 0);
                            dic.Add(charint, input);
                        }
                    }
                    foreach (var pair in dic)
                    {
                        byte[] showchar = Decore(pair.Key);
                        Array.Reverse(showchar);
                        listID.Items.Add(Encoding.UTF8.GetString(showchar));
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = listID.SelectedIndex;
            if (!string.IsNullOrEmpty(idBox.Text) && !string.IsNullOrEmpty(xBox.Text) && !string.IsNullOrEmpty(yBox.Text) && !string.IsNullOrEmpty(wBox.Text) && !string.IsNullOrEmpty(lBox.Text) && !string.IsNullOrEmpty(rBox.Text) && index != ListBox.NoMatches)
            {
                listID.Items.RemoveAt(index);
                listID.Items.Insert(index, idBox.Text);
                long[] new_data = new long[6];
                new_data[0] = long.Parse(xBox.Text);
                new_data[1] = long.Parse(yBox.Text);
                new_data[2] = long.Parse(wBox.Text);
                new_data[3] = long.Parse(lBox.Text);
                new_data[4] = long.Parse(rBox.Text);
                byte[] charint = new byte[8];
                byte[] clog = Encoding.UTF8.GetBytes(idBox.Text);
                Array.Reverse(clog);
                Buffer.BlockCopy(clog, 0, charint, 0, clog.Length);
                new_data[5] = BitConverter.ToInt64(charint, 0);
                dic[dic.ElementAt(index).Key] = new_data;
            }
            listID.SelectedIndex = index;
        }

        private void listID_MouseClick(object sender, MouseEventArgs e)
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
                //RenderMap(result_data[0], result_data[1], result_data[0] + result_data[2], result_data[1]);
            }
        }

        private void xBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex("[^0-9\b]+");
            e.Handled = regex.IsMatch(e.KeyChar.ToString());
        }

        private void getTableCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Path.GetExtension(opf.FileName) == ".p3img")
            {
                if (igg)
                {
                    if (!File.Exists(path + "\\" + filename + ".p3igg_bk"))
                        File.Copy(path + "\\" + filename + ".p3igg", path + "\\" + filename + ".p3igg_bk");
                    var wt = new BinaryWriter(File.Create(path + "\\" + filename + ".p3igg"));
                    var msc = new BinaryReader(new MemoryStream(ResRGBA(ckR.Checked, ckG.Checked, ckB.Checked, ckA.Checked, ckhA.Checked, all)));
                    msc.BaseStream.Seek(128, SeekOrigin.Begin);
                    wt.Write(msc.ReadBytes((int)msc.BaseStream.Length - (int)msc.BaseStream.Position));
                    wt.Close();
                }

                if (cfg)
                {
                    if (!File.Exists(path + "\\" + filename + ".cfg.bin_bk"))
                        File.Copy(path + "\\" + filename + ".cfg.bin", path + "\\" + filename + ".cfg.bin_bk");
                    var wt = new BinaryWriter(File.OpenWrite(path + "\\" + filename + ".cfg.bin"));
                    wt.BaseStream.Seek(64, SeekOrigin.Begin);
                    foreach (var pair in dic)
                    {
                        long[] out_data = pair.Value;
                        wt.BaseStream.Seek(16, SeekOrigin.Current);
                        wt.Write(out_data[5]);
                        wt.Write(out_data[0]);
                        wt.Write(out_data[1]);
                        wt.Write(out_data[2]);
                        wt.Write(out_data[3]);
                        wt.Write(out_data[4]);
                        wt.BaseStream.Seek(8, SeekOrigin.Current);
                    }
                    wt.Close();
                }
            }
            else
            {

            }
            MessageBox.Show("Done!");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
