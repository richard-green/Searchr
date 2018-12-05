using Searchr.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searchr.UI
{
    public partial class ucSearchPanel : UserControl
    {
        private SearchRequest CurrentSearch;

        public ucSearchPanel()
        {
            InitializeComponent();

            dgResults.Columns[0].Width = Config.Settings.ColumnWidth0;
            dgResults.Columns[1].Width = Config.Settings.ColumnWidth1;
            dgResults.Columns[2].Width = Config.Settings.ColumnWidth2;
            dgResults.Columns[3].Width = Config.Settings.ColumnWidth3;
            dgResults.Columns[4].Width = Config.Settings.ColumnWidth4;

            cmbIncludedExtensions.Items.Clear();
            cmbIncludedExtensions.Items.AddRange(Config.CommonIncludedExtensions.ToArray());

            cmbExcludedExtensions.Items.Clear();
            cmbExcludedExtensions.Items.AddRange(Config.CommonExcludedExtensions.ToArray());

            ucDirectory1.Directory.Items.Clear();
            ucDirectory1.Directory.Items.AddRange(Config.CommonDirs.ToArray());

            cmbExcludeFolderNames.Items.Clear();
            cmbExcludeFolderNames.Items.AddRange(Config.CommonExcludedDirs.ToArray());

            btnStop.Enabled = false;
            btnFilter.Enabled = false;
            btnSearch.Enabled = true;

            ButtonColorSet();

            var latest = Config.LatestSearch();

            if (latest != null)
            {
                ucDirectory1.Directory.Text = latest.Directory;
                chkRecursive.Checked = latest.DirectoryOption == SearchOption.AllDirectories;
                txtSearchTerm.Text = latest.SearchTerm;
                chkRegex.Checked = latest.SearchMethod == SearchMethod.SingleLineRegex;
                chkMatchCase.Checked = latest.MatchCase;
                cmbExcludedExtensions.Text = String.Join(",", latest.ExcludeFileWildcards);
                cmbIncludedExtensions.Text = String.Join(",", latest.IncludeFileWildcards);
                cmbExcludeFolderNames.Text = String.Join(",", latest.ExcludeFolderNames);
                chkIncludeHidden.Checked = !latest.ExcludeHidden;
                chkIncludeSystem.Checked = !latest.ExcludeSystem;
                chkIncludeBinaryFiles.Checked = !latest.ExcludeBinaryFiles;
                chkSearchFileContents.Checked = latest.SearchFileContents;
                chkSearchFileName.Checked = latest.SearchFileName;
                chkSearchFilePath.Checked = latest.SearchFilePath;
            }

            SetupCheckBox(chkRecursive);
            SetupCheckBox(chkRegex);
            SetupCheckBox(chkMatchCase);
            SetupCheckBox(chkIncludeHidden);
            SetupCheckBox(chkIncludeSystem);
            SetupCheckBox(chkIncludeBinaryFiles);
            SetupCheckBox(chkSearchFileContents);
            SetupCheckBox(chkSearchFileName);
            SetupCheckBox(chkSearchFilePath);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchNow(false);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SearchNow(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CurrentSearch.Abort();
        }

        private void editWithNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgResults.SelectedCells)
            {
                Process.Start(Config.NotepadPlusPlusLocation(), String.Format("\"{0}\"", Path.Combine(((string)cell.OwningRow.Cells[4].Value), (string)cell.OwningRow.Cells[2].Value)));
            }
        }

        private void exploreHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgResults.SelectedCells)
            {
                Process.Start("explorer.exe", String.Format("/select, \"{0}\"", Path.Combine(((string)cell.OwningRow.Cells[4].Value), (string)cell.OwningRow.Cells[2].Value)));
                break;
            }
        }

        private void commandPromptHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgResults.SelectedCells)
            {
                Process.Start("cmd.exe", String.Format("/k cd /d \"{0}\"", (string)cell.OwningRow.Cells[4].Value));
                break;
            }
        }

        private void clearResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SearchNow(false);
                e.Handled = true;
            }
        }

        public void Clear()
        {
            dgResults.Rows.Clear();
            statusText.Text = "";
        }

        private void SearchNow(bool filter)
        {
            if (String.IsNullOrEmpty(txtSearchTerm.Text))
            {
                MessageBox.Show("No search term");
                return;
            }

            if (System.IO.Directory.Exists(ucDirectory1.Directory.Text) == false)
            {
                MessageBox.Show("Invalid directory");
                return;
            }

            btnStop.Enabled = true;
            btnFilter.Enabled = false;
            btnSearch.Enabled = false;

            ButtonColorSet();

            CurrentSearch = GetSearchRequest();

            SaveCurrentSearch();

            IEnumerable<string> paths = filter ? dgResults.Rows.Cast<DataGridViewRow>().Select(r => Path.Combine((string)r.Cells[4].Value, (string)r.Cells[2].Value)).ToList() :
                                                 Enumerable.Empty<string>();

            dgResults.Rows.Clear();

            var response = filter ? Search.PerformFilter(CurrentSearch, paths) :
                                    Search.PerformSearch(CurrentSearch);

            int totalFiles = 0;
            int totalHits = 0;

            Task.Run(() =>
            {
                try
                {
                    foreach (var result in response.Results.GetConsumingEnumerable(CurrentSearch.CancellationToken))
                    {
                        totalFiles++;
                        totalHits += result.TotalCount;

                        var row = new DataGridViewRow();

                        var icon = IconHelper.GetSmallIconCached(result.File.FullName, result.File.Extension.ToLower());

                        if (icon != null)
                        {
                            row.Cells.Add(new DataGridViewImageCell(true)
                            {
                                Value = icon
                            });
                        }
                        else
                        {
                            row.Cells.Add(new DataGridViewImageCell(false));
                        }

                        row.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = result.TotalCount
                        });

                        row.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = result.File.Name
                        });

                        row.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = result.File.Extension
                        });

                        row.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = result.File.Directory.FullName
                        });

                        dgResults.InvokeAction(dg =>
                        {
                            statusText.Text = $"Found {totalHits:n0} lines in {totalFiles:n0} files";
                            dg.Rows.Add(row);
                        });
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Search failed: {ex.Message}");
                }

                this.InvokeAction(_ =>
                {
                    if (response.Error != null)
                    {
                        MessageBox.Show(response.Error.Message);
                    }

                    btnStop.Enabled = false;
                    btnFilter.Enabled = totalFiles > 0;
                    btnSearch.Enabled = true;

                    ButtonColorSet();
                });
            });
        }

        private SearchRequest GetSearchRequest()
        {
            var directory = ucDirectory1.Directory.Text;

            if (directory.EndsWith("\\") && !directory.EndsWith(":\\"))
            {
                directory = directory.Substring(0, directory.Length - 1);
                ucDirectory1.Directory.Text = directory;
            }

            var request = new SearchRequest()
            {
                Directory = ucDirectory1.Directory.Text,
                DirectoryOption = chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly,
                SearchTerm = txtSearchTerm.Text,
                SearchMethod = chkRegex.Checked ? SearchMethod.SingleLineRegex : SearchMethod.SingleLine,
                MatchCase = chkMatchCase.Checked,
                ParallelSearches = 4,
                ExcludeFileWildcards = GetExtensions(cmbExcludedExtensions.Text),
                IncludeFileWildcards = GetExtensions(cmbIncludedExtensions.Text),
                ExcludeFolderNames = GetFolders(cmbExcludeFolderNames.Text),
                ExcludeSystem = !chkIncludeHidden.Checked,
                ExcludeHidden = !chkIncludeSystem.Checked,
                ExcludeBinaryFiles = !chkIncludeBinaryFiles.Checked,
                SearchFileContents = chkSearchFileContents.Checked,
                SearchFileName = chkSearchFileName.Checked,
                SearchFilePath = chkSearchFilePath.Checked
            };

            return request;
        }

        private List<string> GetExtensions(string text)
        {
            return text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
        }

        private List<string> GetFolders(string text)
        {
            return text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
        }

        private void SaveCurrentSearch()
        {
            using (var sha = new SHA256Managed())
            {
                var serializer = new JsonSerializer();
                var serialized = serializer.Serialize(CurrentSearch);
                var hashCode = Hex.ToString(sha.ComputeHash(serialized));
                var historyFile = Path.Combine(Config.HistoryDirectory, String.Format("{0}.search", hashCode));
                if (File.Exists(historyFile) == false)
                {
                    File.WriteAllBytes(historyFile, serialized);
                }
                else
                {
                    new FileInfo(historyFile).LastWriteTime = DateTime.Now;
                }
            }
        }

        public DataGridView Results()
        {
            return dgResults;
        }

        public TextBox SearchTerm => txtSearchTerm;

        private void SetupCheckBox(CheckBox checkbox)
        {
            checkbox.CheckedChanged += CheckBox_CheckedChanged;

            CheckBox_CheckedChanged(checkbox, null);

            checkbox.Height = 23;
        }

        readonly Color blue = Color.FromArgb(114, 200, 255);
        readonly Color red = Color.FromArgb(255, 161, 175);
        readonly Color green = Color.FromArgb(175, 255, 161);

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkbox)
            {
                Colorise(checkbox, blue, SystemColors.Control);
            }
        }

        private void ButtonColorSet()
        {
            Colorise(btnStop, red, SystemColors.Control);
            Colorise(btnFilter, green, SystemColors.Control);
            Colorise(btnSearch, green, SystemColors.Control);
        }

        private void Colorise(Button btn, Color ifEnabled, Color ifDisabled)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = btn.Enabled ? ifEnabled : ifDisabled;
            btn.FlatAppearance.BorderColor = btn.Enabled ? Darker(ifEnabled) : Darker(ifDisabled, 0.95);
            btn.FlatAppearance.BorderSize = 1;
        }

        private void Colorise(CheckBox chk, Color ifEnabled, Color ifDisabled)
        {
            chk.FlatStyle = FlatStyle.Flat;
            chk.BackColor = chk.Checked ? ifEnabled : ifDisabled;
            chk.FlatAppearance.BorderColor = chk.Checked ? Darker(ifEnabled, 0.9) : Darker(ifDisabled, 0.95);
            chk.FlatAppearance.BorderSize = 1;
        }

        private Color Darker(Color src, double ratio = 0.85)
        {
            return Color.FromArgb((int)Math.Max(0, src.R * ratio),
                                  (int)Math.Max(0, src.G * ratio),
                                  (int)Math.Max(0, src.B * ratio));
        }
    }
}
