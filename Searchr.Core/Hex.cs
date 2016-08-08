using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Searchr.Core
{
	public static class Hex
	{
		public static byte[] ToByteArray(string hex)
		{
			int NumberChars = hex.Length / 2;
			byte[] bytes = new byte[NumberChars];

			using (var sr = new StringReader(hex))
			{
				for (int i = 0; i < NumberChars; i++)
				{
					bytes[i] = Convert.ToByte(new string(new char[2] { (char)sr.Read(), (char)sr.Read() }), 16);
				}
			}

			return bytes;
		}

		public static string ToString(byte[] bytes)
		{
            if (bytes == null || bytes.Length == 0) return String.Empty;
            else return BitConverter.ToString(bytes).Replace("-", "");
		}
	}
}
