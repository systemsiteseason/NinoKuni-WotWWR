using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNUPAK
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("1. Unpack");
            Console.WriteLine("2. Repack");
            var s = Console.ReadLine();

            var dlg = new FolderPicker();
            var opf = new OpenFileDialog();
            opf.Filter = "mnupak file|*.mnupak";

            if (s == "1")
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(opf.FileName))
                    {
                        var path = opf.FileName;
                        var dir = Path.GetDirectoryName(path);
                        var noext = Path.GetFileNameWithoutExtension(path);

                        if(!Directory.Exists(Path.Combine(dir, noext + "_UNP")))
                            Directory.CreateDirectory(Path.Combine(dir, noext + "_UNP"));

                        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        {
                            string header = fs.ReadString(4);
                            if (header == "HP10")
                            {
                                int count = fs.ReadInt32();
                                fs.Skip(8);
                                int offsetName = fs.ReadInt32();
                                int offsetData = fs.ReadInt32();
                                fs.Skip(8);
                                for (int i = 0; i < count; i++)
                                {
                                    fs.Skip(16);
                                    int offset = fs.ReadInt32();
                                    int size = fs.ReadInt32();
                                    int name = fs.ReadInt32();
                                    fs.Skip(4);
                                    var pos_ = fs.Tell();

                                    fs.Seek(name + offsetName, SeekOrigin.Begin);
                                    var strname = fs.ReadString();
                                    fs.Seek(offset + offsetData, SeekOrigin.Begin);
                                    var buffer = fs.ReadBytes(size);
                                    fs.Seek(pos_, SeekOrigin.Begin);

                                    if (!Directory.Exists(Path.Combine(dir, noext + "_UNP", Path.GetDirectoryName(strname))))
                                        Directory.CreateDirectory(Path.Combine(dir, noext + "_UNP", Path.GetDirectoryName(strname)));

                                    var wt = File.Create(Path.Combine(dir, noext + "_UNP", strname));
                                    wt.Write(buffer);
                                    wt.Close();
                                }
                            }



                        }
                    }    
                }
            }   
            else if (s == "2")
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(opf.FileName))
                    {
                        if (!File.Exists(opf.FileName + ".bk"))
                            File.Copy(opf.FileName, opf.FileName + ".bk");

                        var path = opf.FileName;
                        var dir = Path.GetDirectoryName(path);
                        var noext = Path.GetFileNameWithoutExtension(path);

                        if (dlg.ShowDialog(new IntPtr()) == true)
                        {
                            if (!string.IsNullOrEmpty(dlg.ResultName))
                            {
                                using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                                {
                                    string header = fs.ReadString(4);
                                    if (header == "HP10")
                                    {
                                        int count = fs.ReadInt32();
                                        fs.Skip(8);
                                        int offsetName = fs.ReadInt32();
                                        int offsetData = fs.ReadInt32();
                                        fs.Skip(8);
                                        fs.SetLength(offsetData);
                                        var end = 0;
                                        var posend = 0;
                                        for (int i = 0; i < count; i++)
                                        {
                                            fs.Skip(16);
                                            var pos = fs.Tell();
                                            int offset = fs.ReadInt32();
                                            int size = fs.ReadInt32();
                                            int name = fs.ReadInt32();
                                            fs.Skip(4);
                                            var pos_ = fs.Tell();

                                            fs.Seek(name + offsetName, SeekOrigin.Begin);
                                            var strname = fs.ReadString();
                                            fs.Seek(fs.Length, SeekOrigin.Begin);
                                            if (fs.Length % 2048 != 0)
                                            {
                                                var cell = (int)(Math.Ceiling((float)fs.Length / 2048f)) * 2048;
                                                offset = cell -  offsetData;
                                                fs.Seek(cell, SeekOrigin.Begin);
                                            }

                                            if (File.Exists(Path.Combine(dir, noext + "_UNP", strname)))
                                            {
                                                var buffer = File.ReadAllBytes(Path.Combine(dir, noext + "_UNP", strname));
                                                fs.Write(buffer);
                                                size = buffer.Length;
                                            }
                                            fs.Seek(pos, SeekOrigin.Begin);
                                            fs.Write(offset);
                                            fs.Write(size);
                                            fs.Seek(pos_, SeekOrigin.Begin);
                                            end = size;
                                            posend = offset;
                                        }
                                        fs.Seek(8);
                                        var padding = (int)(Math.Ceiling((float)end / 2048f)) * 2048;
                                        fs.Write(padding + posend);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
