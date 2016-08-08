using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Searchr.Core;

namespace Searchr.UI
{
    public partial class frmMain : Form
    {
		private const string HistoryDirectory = @"..\..\History";
		private const string SettingsFile = @"..\..\My.settings";
        private Settings settings;

		public frmMain()
		{
			InitializeComponent();

			LoadSettings(SettingsFile);
			LoadCommonDirs();
			LoadCommonIncludedExtensions();
			LoadCommonExcludedExtensions();
			LoadLatestSearchFromHistory();
		}

		private void LoadCommonDirs()
		{
			var list = EnumerateHistory()
				.Select(s => s.Directory)
				.GroupBy(s => s)
				.ToDictionary(g => g.Key, g => g.Count())
				.OrderByDescending(g => g.Value)
				.Select(g => g.Key);

			cmbDirectory.Items.Clear();
            cmbDirectory.Items.AddRange(list.ToArray());
		}

		private void LoadCommonIncludedExtensions()
		{
			var list = EnumerateHistory()
				.Where(s => s.IncludeFileExtensions.Count > 0)
				.Select(s => String.Join(",", s.IncludeFileExtensions.OrderBy(s2 => s2)))
				.GroupBy(s => s)
				.ToDictionary(g => g.Key, g => g.Count())
				.OrderByDescending(g => g.Value)
				.Select(g => g.Key);

            cmbIncludedExtensions.Items.Clear();
            cmbIncludedExtensions.Items.AddRange(list.ToArray());
		}

		private void LoadCommonExcludedExtensions()
		{
			var list = EnumerateHistory()
				.Where(s => s.ExcludeFileExtensions.Count > 0)
				.Select(s => String.Join(",", s.ExcludeFileExtensions.OrderBy(s2 => s2)))
				.GroupBy(s => s)
				.ToDictionary(g => g.Key, g => g.Count())
				.OrderByDescending(g => g.Value)
				.Select(g => g.Key);

            cmbExcludedExtensions.Items.Clear();
            cmbExcludedExtensions.Items.AddRange(list.ToArray());
		}

		private void LoadLatestSearchFromHistory()
		{
			// Load previous search from history
			var search = EnumerateHistory().FirstOrDefault();

			if (search != null)
			{
				RestoreSettings(search);
			}
		}

		private IEnumerable<SearchRequest> EnumerateHistory()
		{
			return new DirectoryInfo(HistoryDirectory).EnumerateFiles().OrderByDescending(f => f.LastWriteTime).Select(fi => LoadSearch(fi.FullName));
		}

		private SearchRequest LoadSearch(string file)
		{
			var serializer = new JsonSerializer();
			var search = serializer.Deserialize<SearchRequest>(File.ReadAllBytes(file));
			return search;
		}

		private void LoadSettings(string file)
		{
			if (File.Exists(file))
			{
				var serializer = new JsonSerializer();
				settings = serializer.Deserialize<Settings>(File.ReadAllBytes(file));

                this.WindowState = settings.Maximised ? FormWindowState.Maximized : FormWindowState.Normal;
				this.Width = settings.Width;
				this.Height = settings.Height;
				this.dgResults.Columns[0].Width = settings.ColumnWidth0;
				this.dgResults.Columns[1].Width = settings.ColumnWidth1;
                this.dgResults.Columns[2].Width = settings.ColumnWidth2;
                this.dgResults.Columns[3].Width = settings.ColumnWidth3;
                this.dgResults.Columns[4].Width = settings.ColumnWidth4;
			}
		}

		private void SaveSettings(string file)
		{
            settings.Maximised = this.WindowState == FormWindowState.Maximized;
			settings.ColumnWidth0 = this.dgResults.Columns[0].Width;
			settings.ColumnWidth1 = this.dgResults.Columns[1].Width;
            settings.ColumnWidth2 = this.dgResults.Columns[2].Width;
            settings.ColumnWidth3 = this.dgResults.Columns[3].Width;
            settings.ColumnWidth4 = this.dgResults.Columns[4].Width;

			var serializer = new JsonSerializer();
			var serialized = serializer.Serialize(settings);
			File.WriteAllBytes(file, serialized);
		}

		private SearchRequest CurrentSearch;

		private void SaveCurrentSearch()
		{
			using (var sha = new SHA256Managed())
			{
				var serializer = new JsonSerializer();
				var serialized = serializer.Serialize(CurrentSearch);
				var hashCode = Hex.ToString(sha.ComputeHash(serialized));
				var historyFile = Path.Combine(HistoryDirectory, String.Format("{0}.search", hashCode));
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

        private SearchRequest GetSearchRequest()
        {
            var request = new SearchRequest()
            {
                Directory = cmbDirectory.Text,
                DirectoryOption = chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly,
                SearchTerm = txtSearchTerm.Text,
                Method = chkRegex.Checked ? SearchMethod.SingleLineRegex : SearchMethod.SingleLine,
                MatchCase = chkMatchCase.Checked,
                ParallelSearches = 4,
                ExcludeFileExtensions = cmbExcludedExtensions.Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                IncludeFileExtensions = cmbIncludedExtensions.Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                ExcludeFolderNames = cmbExcludeFolderNames.Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                ExcludeSystem = chkExcludeHidden.Checked,
                ExcludeHidden = chkExcludeSystem.Checked
            };

            return request;
        }

        private void RestoreSettings(SearchRequest request)
        {
            cmbDirectory.Text = request.Directory;
            chkRecursive.Checked = request.DirectoryOption == SearchOption.AllDirectories;
            txtSearchTerm.Text = request.SearchTerm;
            chkRegex.Checked = request.Method == SearchMethod.SingleLineRegex;
            chkMatchCase.Checked = request.MatchCase;
            cmbExcludedExtensions.Text = String.Join(",", request.ExcludeFileExtensions);
            cmbIncludedExtensions.Text = String.Join(",", request.IncludeFileExtensions);
            cmbExcludeFolderNames.Text = String.Join(",", request.ExcludeFolderNames);
        }

        #region User Actions

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
                    totalFiles++;
                    totalHits += result.TotalCount;

                    var row = new DataGridViewRow();

                    var iconcell = new DataGridViewImageCell(true);
                    iconcell.Value = IconHelper.GetSmallIcon(result.File.FullName);
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

        private void btnExcludeBinaryFiles_Click(object sender, EventArgs e)
        {
            cmbIncludedExtensions.Text = "";
            cmbExcludedExtensions.Text = ".exe,.dll,.pdb,.bin,.jpg,.gif,.bmp,.jpeg,.png,.pack,.nupkg,.zip,.7z";
        }

		private void editWithNotepadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewCell cell in dgResults.SelectedCells)
			{
				Process.Start(@"C:\Program Files (x86)\Notepad++\notepad++.exe", String.Format("\"{0}\\{1}\"", ((DirectoryInfo)cell.OwningRow.Cells[4].Value).FullName, (string)cell.OwningRow.Cells[2].Value));
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

		private void frmMain_Click(object sender, EventArgs e)
		{
			txtHidden.Focus();
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			SaveSettings(SettingsFile);
		}

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                settings.Width = this.Width;
                settings.Height = this.Height;
            }
        }

        #endregion User Actions
    }
}
