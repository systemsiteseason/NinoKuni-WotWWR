using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNUPAK
{
    public static class FileStreamExtensions
    {
        #region Read
        public static byte[] ReadBytes(this FileStream fileStream, int size)
        {
            byte[] buffer = new byte[size];
            fileStream.Read(buffer, 0, size);
            return buffer;
        }

        public static int[] ReadInts(this FileStream fileStream, int size)
        {
            int[] buffer = new int[size];
            for (int i = 0; i < size; i++)
            {
                buffer[i] = fileStream.ReadInt32();
            }
            return buffer;
        }

        public static short ReadInt16(this FileStream fileStream)
        {
            byte[] buffer = new byte[2];
            fileStream.Read(buffer, 0, 2);
            return BitConverter.ToInt16(buffer, 0);
        }

        public static ushort ReadUInt16(this FileStream fileStream)
        {
            byte[] buffer = new byte[2];
            fileStream.Read(buffer, 0, 2);
            return BitConverter.ToUInt16(buffer, 0);
        }

        public static int ReadInt32(this FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer, 0, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public static uint ReadUInt32(this FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer, 0, 4);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static long ReadInt64(this FileStream fileStream)
        {
            byte[] buffer = new byte[8];
            fileStream.Read(buffer, 0, 8);
            return BitConverter.ToInt64(buffer, 0);
        }

        public static ulong ReadUInt64(this FileStream fileStream)
        {
            byte[] buffer = new byte[8];
            fileStream.Read(buffer, 0, 8);
            return BitConverter.ToUInt64(buffer, 0);
        }

        public static float ReadSingle(this FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer, 0, 4);
            return BitConverter.ToSingle(buffer, 0);
        }

        public static double ReadDouble(this FileStream fileStream)
        {
            byte[] buffer = new byte[8];
            fileStream.Read(buffer, 0, 8);
            return BitConverter.ToDouble(buffer, 0);
        }

        public static short ReadInt16BE(this FileStream fileStream)
        {
            byte[] buffer = new byte[2];
            fileStream.Read(buffer, 0, 2);
            Array.Reverse(buffer);
            return BitConverter.ToInt16(buffer, 0);
        }

        public static ushort ReadUInt16BE(this FileStream fileStream)
        {
            byte[] buffer = new byte[2];
            fileStream.Read(buffer, 0, 2);
            Array.Reverse(buffer);
            return BitConverter.ToUInt16(buffer, 0);
        }

        public static int ReadInt32BE(this FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

        public static uint ReadUInt32BE(this FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static long ReadInt64BE(this FileStream fileStream)
        {
            byte[] buffer = new byte[8];
            fileStream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        public static ulong ReadUInt64BE(this FileStream fileStream)
        {
            byte[] buffer = new byte[8];
            fileStream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }

        public static float ReadSingleBE(this FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        public static double ReadDoubleBE(this FileStream fileStream)
        {
            byte[] buffer = new byte[8];
            fileStream.Read(buffer, 0, 8);
            Array.Reverse(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        public static byte[] ReadEndByte(this FileStream fileStream)
        {
            List<byte> res = new List<byte>();
            while (true)
            {
                byte read = (byte)fileStream.ReadByte();
                res.Add(read);
                if (read == 0) break;
            }
            return res.ToArray();
        }

        public static string ReadString(this FileStream fileStream, int size)
        {
            return Encoding.ASCII.GetString(fileStream.ReadBytes(size));
        }

        public static string ReadString(this FileStream fileStream)
        {
            List<byte> res = new List<byte>();
            while (true)
            {
                byte read = (byte)fileStream.ReadByte();
                if (read == 0)
                    break;
                
                res.Add(read);
            }
            return Encoding.UTF8.GetString(res.ToArray());
        }
        #endregion

        #region Write
        public static void Write(this FileStream fileStream, byte[] _array)
        {
            fileStream.Write(_array, 0, _array.Length);
        }

        public static void Write(this FileStream fileStream, short _short)
        {
            fileStream.Write(BitConverter.GetBytes(_short), 0, 2);
        }

        public static void Write(this FileStream fileStream, ushort _ushort)
        {
            fileStream.Write(BitConverter.GetBytes(_ushort), 0, 2);
        }

        public static void Write(this FileStream fileStream, int _int)
        {
            fileStream.Write(BitConverter.GetBytes(_int), 0, 4);
        }

        public static void Write(this FileStream fileStream, uint _uint)
        {
            fileStream.Write(BitConverter.GetBytes(_uint), 0, 4);
        }

        public static void Write(this FileStream fileStream, long _long)
        {
            fileStream.Write(BitConverter.GetBytes(_long), 0, 8);
        }

        public static void Write(this FileStream fileStream, ulong _ulong)
        {
            fileStream.Write(BitConverter.GetBytes(_ulong), 0, 8);
        }

        public static void Write(this FileStream fileStream, float _float)
        {
            fileStream.Write(BitConverter.GetBytes(_float), 0, 4);
        }

        public static void Write(this FileStream fileStream, double _double)
        {
            fileStream.Write(BitConverter.GetBytes(_double), 0, 8);
        }
        #endregion

        #region Method
        public static void Insert(this FileStream fileStream, byte[] dest, int offset)
        {
            var buffer = new byte[4096];
            var length = fileStream.Length;
            fileStream.SetLength(fileStream.Length + dest.LongLength);
            long pos = length;
            int next_pos;
            while (pos > offset)
            {
                next_pos = pos - 4096 >= offset ? 4096 : (int)(pos - offset);
                pos -= next_pos;
                fileStream.Position = pos;
                fileStream.Read(buffer, 0, next_pos);
                fileStream.Position = pos + dest.LongLength;
                fileStream.Write(buffer, 0, next_pos);
            }
            fileStream.Position = offset;
            fileStream.Write(dest, 0, dest.Length);
            fileStream.Flush();
        }

        public static void Remove(this FileStream fileStream, int size, int offset)
        {
            var buffer = new byte[4096];
            var length = fileStream.Length;
            long pos = offset + size;
            int next_pos;
            while (pos < length)
            {
                next_pos = pos + 4096 <= length ? 4096 : (int)(length - pos);
                fileStream.Position = pos;
                fileStream.Read(buffer, 0, next_pos);
                fileStream.Position = pos - size;
                fileStream.Write(buffer, 0, next_pos);
                pos += next_pos;
            }
            fileStream.SetLength(length - size);
            fileStream.Flush();
        }

        public static void Seek(this FileStream fileStream, int to)
        {
            fileStream.Seek(to, SeekOrigin.Begin);
        }

        public static void Skip(this FileStream fileStream, int to)
        {
            fileStream.Seek(to, SeekOrigin.Current);
        }

        public static long Tell(this FileStream fileStream)
        {
            return fileStream.Position;
        }

        public static int Tell32(this FileStream fileStream)
        {
            return (int)fileStream.Position;
        }
        #endregion
    }
}
