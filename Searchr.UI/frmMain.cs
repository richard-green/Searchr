using System;
using System.Linq;
using System.Windows.Forms;

namespace Searchr.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            AddResultsTab();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            txtHidden.Focus();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                Config.Settings.Width = Width;
                Config.Settings.Height = Height;
            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                var panel = resultsTabs.SelectedTab.Controls[0] as ucSearchPanel;

                if (panel != null)
                {
                    panel.CurrentSearch?.Abort();
                }
            }
        }

        private void resultsTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsTabs.SelectedIndex == resultsTabs.TabCount - 1)
            {
                AddResultsTab();
            }
        }

        private void resultsTabs_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            var tabs = tabControl.TabPages;

            if (e.Button == MouseButtons.Middle)
            {
                var tabToRemove = tabs.OfType<TabPage>()
                                      .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location) && i < tabs.Count - 1)
                                      .FirstOrDefault();

                if (tabToRemove != null) tabs.Remove(tabToRemove);
            }
        }

        private void SaveSettings()
        {
            var currentResults = CurrentResults();

            if (currentResults != null)
            {
                Config.Settings.ColumnWidth0 = currentResults.Columns[0].Width;
                Config.Settings.ColumnWidth1 = currentResults.Columns[1].Width;
                Config.Settings.ColumnWidth2 = currentResults.Columns[2].Width;
                Config.Settings.ColumnWidth3 = currentResults.Columns[3].Width;
                Config.Settings.ColumnWidth4 = currentResults.Columns[4].Width;
                Config.Settings.ColumnWidth5 = currentResults.Columns[5].Width;
            }

            Config.Settings.Maximised = WindowState == FormWindowState.Maximized;
            Config.SaveSettings();
        }

        private DataGridView CurrentResults() => CurrentSearchPanel?.Results();

        private ucSearchPanel CurrentSearchPanel => resultsTabs.SelectedTab.Controls.OfType<ucSearchPanel>().FirstOrDefault();

        private void AddResultsTab()
        {
            var newTab = CreateTabPage();
            resultsTabs.TabPages.Insert(resultsTabs.TabCount - 1, newTab);
            resultsTabs.SelectedTab = newTab;

            if (newTab.Controls[0] is ucSearchPanel p)
            {
                p.Setup();
                p.SearchTerm.Focus();
            }
        }

        private TabPage CreateTabPage()
        {
            var newTab = new TabPage();
            newTab.Padding = new Padding(7);
            newTab.TabIndex = 0;
            newTab.Text = "Searchr";
            newTab.UseVisualStyleBackColor = true;

            var panel = new ucSearchPanel();
            panel.Dock = DockStyle.Fill;
            newTab.Controls.Add(panel);

            return newTab;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                CurrentSearchPanel.SearchTerm.Focus();
                CurrentSearchPanel.SearchTerm.SelectAll();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.T))
            {
                AddResultsTab();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.W))
            {
                if (resultsTabs.TabPages.Count == 2)
                {
                    CurrentSearchPanel.Clear();
                    resultsTabs.SelectedTab.Text = "Searchr";
                }
                else
                {
                    var tabToRemove = resultsTabs.SelectedTab;
                    var currentIndex = resultsTabs.SelectedIndex;
                    if (currentIndex == resultsTabs.TabCount - 2) currentIndex--;
                    resultsTabs.TabPages.Remove(tabToRemove);
                    resultsTabs.SelectedIndex = currentIndex;
                }
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.Control | Keys.Tab))
            {
                if (resultsTabs.TabPages.Count > 1)
                {
                    var newIndex = resultsTabs.SelectedIndex - 1;
                    if (newIndex == -1) newIndex = resultsTabs.TabPages.Count - 2;
                    resultsTabs.SelectedIndex = newIndex;
                }
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Tab))
            {
                if (resultsTabs.TabPages.Count > 1)
                {
                    var newIndex = resultsTabs.SelectedIndex + 1;
                    if (newIndex >= resultsTabs.TabPages.Count - 1) newIndex = 0;
                    resultsTabs.SelectedIndex = newIndex;
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
