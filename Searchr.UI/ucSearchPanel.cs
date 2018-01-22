using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Searchr.Core;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

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
                chkRegex.Checked = latest.Method == SearchMethod.SingleLineRegex;
                chkMatchCase.Checked = latest.MatchCase;
                cmbExcludedExtensions.Text = String.Join(",", latest.ExcludeFileExtensions);
                cmbIncludedExtensions.Text = String.Join(",", latest.IncludeFileExtensions);
                cmbExcludeFolderNames.Text = String.Join(",", latest.ExcludeFolderNames);
                chkExcludeHidden.Checked = latest.ExcludeHidden;
                chkExcludeSystem.Checked = latest.ExcludeSystem;
                chkExcludeBinaryFiles.Checked = latest.ExcludeBinaryFiles;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

                        var iconcell = new DataGridViewImageCell(true);
                        var icon = IconHelper.GetSmallIconCached(result.File.FullName, result.File.Extension);
                        if (icon != null)
                        {
                            iconcell.Value = icon;
                        }
                        row.Cells.Add(iconcell);

                        var hitcell = new DataGridViewTextBoxCell();
                        hitcell.Value = result.TotalCount;
                        row.Cells.Add(hitcell);

                        var filecell = new DataGridViewTextBoxCell();
                        filecell.Value = result.File.Name;
                        row.Cells.Add(filecell);

                        var extcell = new DataGridViewTextBoxCell();
                        extcell.Value = result.File.Extension;
                        row.Cells.Add(extcell);

                        var dircell = new DataGridViewTextBoxCell();
                        dircell.Value = result.File.Directory;
                        row.Cells.Add(dircell);

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
                    btnSearch.Enabled = true;
                    btnStop.Enabled = false;
                });
            });
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
            dgResults.Rows.Clear();
        }

        private void chk_Changed(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            checkbox.ImageIndex = (checkbox.Checked) ? 3 : 2;
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
                Method = chkRegex.Checked ? SearchMethod.SingleLineRegex : SearchMethod.SingleLine,
                MatchCase = chkMatchCase.Checked,
                ParallelSearches = 4,
                ExcludeFileExtensions = GetExtensions(cmbExcludedExtensions.Text),
                IncludeFileExtensions = GetExtensions(cmbIncludedExtensions.Text),
                ExcludeFolderNames = GetFolders(cmbExcludeFolderNames.Text),
                ExcludeSystem = chkExcludeHidden.Checked,
                ExcludeHidden = chkExcludeSystem.Checked,
                ExcludeBinaryFiles = chkExcludeBinaryFiles.Checked
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
    }
}
