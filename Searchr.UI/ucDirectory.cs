using System.Windows.Forms;

namespace Searchr.UI
{
    public partial class ucDirectory : UserControl
    {
        public ucDirectory()
        {
            InitializeComponent();
        }

        public ComboBox Directory => cmbDirectory;

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var directory = cmbDirectory.Text;
                if (System.IO.Directory.Exists(directory)) dialog.SelectedPath = directory;
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    cmbDirectory.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
