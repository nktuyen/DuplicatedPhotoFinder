using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicatedFileFinder
{
    public delegate void DirectoryListChange(EventArgs e);
    public partial class MainForm : Form
    {
        private event DirectoryListChange DirectoryListChanged;

        public MainForm()
        {
            InitializeComponent();

            DirectoryListChanged += new DirectoryListChange(OnDirectoriesListChanged);
        }

        private void OnDirectoriesListChanged(EventArgs e)
        {
            StartButton.Enabled = (DirectoriesListView.Items.Count > 0) && (FilterSizeTypeCombo.SelectedIndex == 0 || FilterSizeValueTextBox.TextLength > 0);
            RemoveAllDirectoryMenuItem.Enabled = DirectoriesListView.Items.Count > 0;
        }

        private void DirectoriesListView_ItemActivate(object sender, EventArgs e)
        {
            RemoveDirectoryMenuItem.Enabled = DirectoriesListView.SelectedItems.Count > 0;
        }

        private void DirectoriesListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void directoriesListContextMenu_Opening(object sender, CancelEventArgs e)
        {
            RemoveDirectoryMenuItem.Enabled = DirectoriesListView.SelectedItems.Count > 0;
            RemoveAllDirectoryMenuItem.Enabled = DirectoriesListView.Items.Count > 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DirectoriesListView.Columns[1].Width = DirectoriesListView.Width - DirectoriesListView.Columns[0].Width - 40;
            FilterFileTypesTextBox.Text = "*.*";
            FilterSizeTypeCombo.SelectedIndex = 0;
            FilterSizeUnitCombo.SelectedIndex = 0;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            DirectoriesListView.Columns[1].Width = DirectoriesListView.Width - DirectoriesListView.Columns[0].Width-40;
        }

        private void AddDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            if (DirectoryBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            ListViewItem item = null;
            for (int i = 0; i < DirectoriesListView.Items.Count; i++) {
                item = DirectoriesListView.Items[i] as ListViewItem;
                if (string.Compare(item.SubItems[1].Text, DirectoryBrowserDialog.SelectedPath, true) == 0) {
                    MessageBox.Show("Selected directory is already in the list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            item = DirectoriesListView.Items.Add(string.Format("{0}", DirectoriesListView.Items.Count + 1));
            item.SubItems.Add(DirectoryBrowserDialog.SelectedPath);
            DirectoryListChanged?.Invoke(new EventArgs());
        }

        private void RemoveDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = DirectoriesListView.SelectedItems[0] as ListViewItem;
            if (item == null)
                return;
            if (MessageBox.Show("Are you sure to remove selected directori(es) from the list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            foreach (var i in DirectoriesListView.SelectedItems)
            {
                DirectoriesListView.Items.Remove(i as ListViewItem);
            }
            DirectoryListChanged?.Invoke(new EventArgs());
        }

        private void RemoveAllDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryListChanged?.Invoke(new EventArgs());
            if (MessageBox.Show("Are you sure to remove all directori(es) in the list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            DirectoriesListView.Items.Clear();
            DirectoryListChanged?.Invoke(new EventArgs());
        }

        private void FilterSizeValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8) {
                if (!char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void FilterSizeTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSizeValueTextBox.Visible = FilterSizeTypeCombo.SelectedIndex > 0;
            FilterSizeUnitCombo.Visible = FilterSizeTypeCombo.SelectedIndex > 0;
            StartButton.Enabled = (DirectoriesListView.Items.Count > 0) && (FilterSizeTypeCombo.SelectedIndex == 0 || FilterSizeValueTextBox.TextLength > 0);
        }

        private void FilterSizeValueTextBox_TextChanged(object sender, EventArgs e)
        {
            StartButton.Enabled = (DirectoriesListView.Items.Count > 0) && (FilterSizeTypeCombo.SelectedIndex == 0 || FilterSizeValueTextBox.TextLength > 0);
        }

        private void FilterSizeUnitCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartButton.Enabled = (DirectoriesListView.Items.Count > 0) && (FilterSizeTypeCombo.SelectedIndex == 0 || FilterSizeValueTextBox.TextLength > 0);
        }

        

        private void StartButton_Click(object sender, EventArgs e)
        {
           
        }

        private void StopButton_Click(object sender, EventArgs e)
        {

        }

        private void FileScanningWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void FileScanningWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void FileScanningWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void AnalyzerWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void AnalyzerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void AnalyzerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
