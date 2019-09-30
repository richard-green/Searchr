using System;
using System.IO;

namespace Searchr.Core
{
    public static class Hex
    {
        public static byte[] ToByteArray(string hex)
        {
            int chars = hex.Length / 2;
            byte[] bytes = new byte[chars];

            using (var sr = new StringReader(hex))
            {
                for (int i = 0; i < chars; i++)
                {
                    bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
                }
            }

            return bytes;
        }

        public static string ToString(byte[] bytes)
        {
            return (bytes == null || bytes.Length == 0) ?
                string.Empty :
                BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}
