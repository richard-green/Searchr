using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Searchr.UI
{
    public static class IconHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
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
        public const uint SHGFI_LARGEICON = 0x0;
        public const uint SHGFI_SMALLICON = 0x1;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x10;

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string path, uint fattrs, ref SHFILEINFO sfi, uint size, uint flags);

        [DllImport("user32.dll")]
        private static extern void DestroyIcon(IntPtr handle);

        public static Icon GetSmallIcon(string path)
        {
            SHFILEINFO info = new SHFILEINFO();
            SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES);
            try
            {
                var icon = (Icon)Icon.FromHandle(info.handle).Clone();
                DestroyIcon(info.handle);
                return icon;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Icon GetLargeIcon(string path)
        {
            SHFILEINFO info = new SHFILEINFO();
            SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_LARGEICON | SHGFI_USEFILEATTRIBUTES);
            try
            {
                var icon = (Icon)Icon.FromHandle(info.handle).Clone();
                DestroyIcon(info.handle);
                return icon;
            }
            catch (Exception)
            {
                return null;
            }
        }

        static readonly ConcurrentDictionary<string, Icon> smallIconCache = new ConcurrentDictionary<string, Icon>();

        public static Icon GetSmallIconCached(string path, string extension)
        {
            if (File.Exists(path) && extension.InList(".exe", ".ico")) return GetSmallIcon(path);
            return smallIconCache.GetOrAdd(extension, _ => GetSmallIcon(extension));
        }

        static readonly ConcurrentDictionary<string, Icon> largeIconCache = new ConcurrentDictionary<string, Icon>();

        public static Icon GetLargeIconCached(string path, string extension)
        {
            if (File.Exists(path) && extension.InList(".exe", ".ico")) return GetLargeIcon(path);
            return largeIconCache.GetOrAdd(extension, _ => GetLargeIcon(extension));
        }
    }
}
