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

        Rectangle rect;

        Point LocationXlYt;
        Point LocationXrYb;

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
                                byte[] done = new byte[head.Length + 12 + argb.Length + data_raw.Length];
                                Buffer.BlockCopy(head, 0, done, 0, head.Length);
                                Buffer.BlockCopy(BitConverter.GetBytes(height), 0, done, head.Length, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(width), 0, done, head.Length + 4, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(data_raw.Length), 0, done, head.Length + 8, 4);
                                Buffer.BlockCopy(argb, 0, done, head.Length + 12, argb.Length);
                                Buffer.BlockCopy(data_raw, 0, done, head.Length + 12 + argb.Length, data_raw.Length);
                                TexDDS(done);
                            }
                            else
                            {
                                typeF.Text = "Texture (BC7)";
                                byte[] done = new byte[head.Length + 12 + bc7.Length + data_raw.Length];
                                Buffer.BlockCopy(head, 0, done, 0, head.Length);
                                Buffer.BlockCopy(BitConverter.GetBytes(height), 0, done, head.Length, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(width), 0, done, head.Length + 4, 4);
                                Buffer.BlockCopy(BitConverter.GetBytes(data_raw.Length), 0, done, head.Length + 8, 4);
                                Buffer.BlockCopy(bc7, 0, done, head.Length + 12, bc7.Length);
                                Buffer.BlockCopy(data_raw, 0, done, head.Length + 12 + bc7.Length, data_raw.Length);
                                TexDDS(done);
                            }

                        }
                        else
                        {
                            MessageBox.Show("No p3igg file found!");
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
                e.Graphics.DrawRectangle(Pens.Red, GetRect());
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
    }
}
