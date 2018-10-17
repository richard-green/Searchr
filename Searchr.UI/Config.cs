using Searchr.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Searchr.UI
{
    public static class Config
    {
        private const string SettingsFile = @"My.settings";
        private const string NotepadPlusPlus = @"C:\Program Files\Notepad++\notepad++.exe";
        private const string NotepadPlusPlus86 = @"C:\Program Files (x86)\Notepad++\notepad++.exe";

        public static Settings Settings { get; private set; } = LoadSettings(SettingsFile);

        public static string HistoryDirectory { get; private set; } = FindHistoryDirectory();

        private static string FindHistoryDirectory()
        {
            return FindDirectory("History") ?? (Debugger.IsAttached ? @"..\..\History" : "History");
        }

        private static string FindDirectory(string dir, int searchDepth = 0)
        {
            if (Directory.Exists(dir))
            {
                return dir;
            }
            else if (searchDepth == 2)
            {
                return null;
            }
            else
            {
                dir = Path.Combine("..", dir);
                return FindDirectory(dir, searchDepth + 1);
            }
        }

        public static string NotepadPlusPlusLocation()
        {
            if (File.Exists(NotepadPlusPlus))
            {
                return NotepadPlusPlus;
            }
            else if (File.Exists(NotepadPlusPlus86))
            {
                return NotepadPlusPlus86;
            }
            else
            {
                return null;
            }
        }

        public static List<string> CommonDirs
        {
            get
            {
                return EnumerateHistory()
                        .Select(s => s.Directory)
                        .GroupBy(s => s)
                        .ToDictionary(g => g.Key, g => g.Count())
                        .OrderByDescending(g => g.Value)
                        .Select(g => g.Key)
                        .ToList();
            }
        }

        public static List<string> CommonIncludedExtensions
        {
            get
            {
                return EnumerateHistory()
                        .Where(s => s.IncludeFileWildcards.Count > 0)
                        .Select(s => String.Join(",", s.IncludeFileWildcards.OrderBy(s2 => s2)))
                        .GroupBy(s => s)
                        .ToDictionary(g => g.Key, g => g.Count())
                        .OrderByDescending(g => g.Value)
                        .Select(g => g.Key)
                        .ToList();
            }
        }

        public static List<string> CommonExcludedExtensions
        {
            get
            {
                return EnumerateHistory()
                        .Where(s => s.ExcludeFileWildcards.Count > 0)
                        .Select(s => String.Join(",", s.ExcludeFileWildcards.OrderBy(s2 => s2)))
                        .GroupBy(s => s)
                        .ToDictionary(g => g.Key, g => g.Count())
                        .OrderByDescending(g => g.Value)
                        .Select(g => g.Key)
                        .ToList();
            }
        }

        public static List<string> CommonExcludedDirs
        {
            get
            {
                return EnumerateHistory()
                        .Where(s => s.ExcludeFolderNames.Count > 0)
                        .Select(s => String.Join(",", s.ExcludeFolderNames.OrderBy(s2 => s2)))
                        .GroupBy(s => s)
                        .ToDictionary(g => g.Key, g => g.Count())
                        .OrderByDescending(g => g.Value)
                        .Select(g => g.Key)
                        .ToList();
            }
        }

        public static SearchRequest LatestSearch()
        {
            return EnumerateHistory().FirstOrDefault();
        }

        private static IEnumerable<SearchRequest> EnumerateHistory()
        {
            var dir = new DirectoryInfo(HistoryDirectory);

            if (!dir.Exists)
            {
                dir.Create();
            }

            return dir.EnumerateFiles().OrderByDescending(f => f.LastWriteTime).Select(fi => LoadSearch(fi.FullName));
        }

        private static SearchRequest LoadSearch(string file)
        {
            var serializer = new JsonSerializer();
            var search = serializer.Deserialize<SearchRequest>(File.ReadAllBytes(file));
            return search;
        }

        private static Settings LoadSettings(string file)
        {
            if (File.Exists(file))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Settings>(File.ReadAllBytes(file));
            }
            else
            {
                return new Settings()
                {
                    Maximised = false,
                    Width = 1024,
                    Height = 768,
                    ColumnWidth0 = 100,
                    ColumnWidth1 = 100,
                    ColumnWidth2 = 100,
                    ColumnWidth3 = 100,
                    ColumnWidth4 = 100
                };
            }
        }

        public static void SaveSettings()
        {
            var serializer = new JsonSerializer();
            var serialized = serializer.Serialize(Settings);
            File.WriteAllBytes(SettingsFile, serialized);
        }
    }
}
