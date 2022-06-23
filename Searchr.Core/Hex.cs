using System;
using System.IO;

namespace Searchr.Core
{
    /// <summary>
    /// Hex encoding / decoding
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// Encodes a byte array to a Hex string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encode(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            if (bytes.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// Decodes a Hex string to a byte array
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] Decode(string hex)
        {
            if (hex is null) throw new ArgumentNullException(nameof(hex));

            int length = hex.Length / 2;

            if (length == 0)
            {
                return Array.Empty<byte>();
            }
            else
            {
                byte[] bytes = new byte[length];

                using (var sr = new StringReader(hex))
                {
                    for (int i = 0; i < length; i++)
                    {
                        bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
                    }
                }

                return bytes;
            }
        }
    }
}
