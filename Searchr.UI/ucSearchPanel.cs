using Searchr.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

            cmbDirectory.Items.Clear();
            cmbDirectory.Items.AddRange(Config.CommonDirs.ToArray());

            cmbExcludeFolderNames.Items.Clear();
            cmbExcludeFolderNames.Items.AddRange(Config.CommonExcludedDirs.ToArray());

            var latest = Config.LatestSearch();

            if (latest != null)
            {
                cmbDirectory.Text = latest.Directory;
                chkRecursive.Checked = latest.DirectoryOption == SearchOption.AllDirectories;
                txtSearchTerm.Text = latest.SearchTerm;
                chkRegex.Checked = latest.SearchMethod == SearchMethod.SingleLineRegex;
                chkMatchCase.Checked = latest.MatchCase;
                cmbExcludedExtensions.Text = String.Join(",", latest.ExcludeFileExtensions);
                cmbIncludedExtensions.Text = String.Join(",", latest.IncludeFileExtensions);
                cmbExcludeFolderNames.Text = String.Join(",", latest.ExcludeFolderNames);
                chkIncludeHidden.Checked = !latest.ExcludeHidden;
                chkIncludeSystem.Checked = !latest.ExcludeSystem;
                chkIncludeBinaryFiles.Checked = !latest.ExcludeBinaryFiles;
                chkSearchFileContents.Checked = latest.SearchFileContents;
                chkSearchFileName.Checked = latest.SearchFileName;
                chkSearchFilePath.Checked = latest.SearchFilePath;

                CheckBox_CheckedChanged(chkRecursive, null);
                CheckBox_CheckedChanged(chkRegex, null);
                CheckBox_CheckedChanged(chkMatchCase, null);
                CheckBox_CheckedChanged(chkIncludeHidden, null);
                CheckBox_CheckedChanged(chkIncludeSystem, null);
                CheckBox_CheckedChanged(chkIncludeBinaryFiles, null);
                CheckBox_CheckedChanged(chkSearchFileContents, null);
                CheckBox_CheckedChanged(chkSearchFileName, null);
                CheckBox_CheckedChanged(chkSearchFilePath, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchNow();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CurrentSearch.Abort();
        }

        private void editWithNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgResults.SelectedCells)
            {
                Process.Start(Config.NotepadPlusPlusLocation(), String.Format("\"{0}\\{1}\"", ((DirectoryInfo)cell.OwningRow.Cells[4].Value).FullName, (string)cell.OwningRow.Cells[2].Value));
            }
        }

        private void exploreHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgResults.SelectedCells)
            {
                Process.Start("explorer.exe", String.Format("/select, \"{0}\\{1}\"", ((DirectoryInfo)cell.OwningRow.Cells[4].Value).FullName, (string)cell.OwningRow.Cells[2].Value));
                break;
            }
        }

        private void commandPromptHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgResults.SelectedCells)
            {
                Process.Start("cmd.exe", String.Format("/k cd /d \"{0}\"", ((DirectoryInfo)cell.OwningRow.Cells[4].Value).FullName));
                break;
            }
        }

        private void clearResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void chk_Changed(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            checkbox.ImageIndex = (checkbox.Checked) ? 3 : 2;
        }

        private void txtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SearchNow();
            }
        }

        public void Clear()
        {
            dgResults.Rows.Clear();
        }

        private void SearchNow()
        {
            if (String.IsNullOrEmpty(txtSearchTerm.Text))
            {
                MessageBox.Show("No search term");
                return;
            }

            if (System.IO.Directory.Exists(cmbDirectory.Text) == false)
            {
                MessageBox.Show("Invalid directory");
                return;
            }

            btnSearch.Enabled = false;
            btnStop.Enabled = true;

            CurrentSearch = GetSearchRequest();

            SaveCurrentSearch();

            dgResults.Rows.Clear();

            var response = Search.PerformSearch(CurrentSearch);

            int totalFiles = 0;
            int totalHits = 0;

            Task.Run(() =>
            {
                foreach (var result in response.Results.GetConsumingEnumerable())
                {
                    try
                    {
                        totalFiles++;
                        totalHits += result.TotalCount;

                        var row = new DataGridViewRow();

                        row.Cells.Add(new DataGridViewImageCell(true)
                        {
                            Value = IconHelper.GetSmallIconCached(result.File.FullName, result.File.Extension.ToLower())
                        });

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
                            Value = result.File.Directory
                        });

                        dgResults.InvokeAction(dg =>
                        {
                            dgResults.Rows.Add(row);
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                this.InvokeAction(_ =>
                {
                    if (response.Error != null)
                    {
                        MessageBox.Show(response.Error.Message);
                    }

                    btnSearch.Enabled = true;
                    btnStop.Enabled = false;
                });
            });
        }

        private SearchRequest GetSearchRequest()
        {
            if (cmbDirectory.Text.EndsWith("\\") && !cmbDirectory.Text.EndsWith(":\\"))
            {
                cmbDirectory.Text = cmbDirectory.Text.Substring(0, cmbDirectory.Text.Length - 1);
            }

            var request = new SearchRequest()
            {
                Directory = cmbDirectory.Text,
                DirectoryOption = chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly,
                SearchTerm = txtSearchTerm.Text,
                SearchMethod = chkRegex.Checked ? SearchMethod.SingleLineRegex : SearchMethod.SingleLine,
                MatchCase = chkMatchCase.Checked,
                ParallelSearches = 4,
                ExcludeFileExtensions = GetExtensions(cmbExcludedExtensions.Text),
                IncludeFileExtensions = GetExtensions(cmbIncludedExtensions.Text),
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

        private IList<string> GetExtensions(string text)
        {
            return text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Select(ext => ext.StartsWith(".") ? ext : $".{ext}").Distinct().ToList();
        }

        private IList<string> GetFolders(string text)
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

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkbox)
            {
                checkbox.BackColor = checkbox.Checked ? System.Drawing.Color.SkyBlue : System.Drawing.Color.White;
            }
        }
    }
}
