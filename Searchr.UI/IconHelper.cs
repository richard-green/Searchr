using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Searchr.UI
{
	public static class IconHelper
	{
		[StructLayout(LayoutKind.Sequential)]
		public struct SHFILEINFO
		{
			public IntPtr handle;
			public IntPtr index;
			public uint attr;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string display;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string type;
		};
		public const uint SHGFI_ICON = 0x100;
		public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
		public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string path, uint fattrs, ref SHFILEINFO sfi, uint size, uint flags);
		public static Icon GetSmallIcon(string path)
		{
			SHFILEINFO info = new SHFILEINFO();
			SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_SMALLICON);
			try
			{
				return Icon.FromHandle(info.handle);
			}
			catch (Exception)
			{
				return null;
			}
		}
		public static Icon GetLargeIcon(string path)
		{
			SHFILEINFO info = new SHFILEINFO();
			SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_LARGEICON);
			try
			{
				return Icon.FromHandle(info.handle);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
