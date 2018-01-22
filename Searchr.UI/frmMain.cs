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

        private void resultsTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsTabs.SelectedIndex == resultsTabs.TabCount - 1)
            {
                AddResultsTab();
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
            }

            Config.Settings.Maximised = WindowState == FormWindowState.Maximized;
            Config.SaveSettings();
        }

        private DataGridView CurrentResults()
        {
            return resultsTabs.SelectedTab.Controls.OfType<ucSearchPanel>().FirstOrDefault()?.Results();
        }

        private void AddResultsTab()
        {
            var newTab = CreateTabPage();
            resultsTabs.TabPages.Insert(resultsTabs.TabCount - 1, newTab);
            resultsTabs.SelectedTab = newTab;
        }

        private TabPage CreateTabPage()
        {
            var newTab = new TabPage();
            newTab.Padding = new Padding(5);
            newTab.TabIndex = 0;
            newTab.Text = "Search";
            newTab.UseVisualStyleBackColor = true;

            var panel = new ucSearchPanel();
            panel.Dock = DockStyle.Fill;
            newTab.Controls.Add(panel);

            return newTab;
        }
    }
}
