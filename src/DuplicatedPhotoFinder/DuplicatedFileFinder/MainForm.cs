using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DuplicatedFileFinder
{
    public delegate void DirectoryListChange(EventArgs e);
    public partial class MainForm : Form
    {
        private readonly List<string> Directories = new List<string>();
        private readonly Dictionary<string, List<string>> DuplicatedFilesMap = new Dictionary<string, List<string>>();

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
            this.Directories.Clear();
            this.DuplicatedFilesMap.Clear();
            foreach(ListViewItem item in DirectoriesListView.Items)
            {
                this.Directories.Add(item.SubItems[1].Text);
            }
            AnalyzerWorker.RunWorkerAsync(this.Directories);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (AnalyzerWorker.IsBusy)
                AnalyzerWorker.CancelAsync();
        }

        private void AnalyzerWorker_Prepare(object sender, EventArgs e)
        {
            if (StartButton.InvokeRequired)
                StartButton.Invoke(new MethodInvoker(delegate { StartButton.Visible = false; }));
            else
                StartButton.Visible = false;
            if (StopButton.InvokeRequired)
                StopButton.Invoke(new MethodInvoker(delegate { StopButton.Visible = true; }));
            else
                StopButton.Visible = true;
            if (StatusBar.InvokeRequired)
                StatusBar.Invoke(new MethodInvoker(delegate {
                    StatusProgress.Visible = true;
                    StatusText.Visible = true;
                    StatusText.Text = string.Empty;
                }));
            else
            {
                StatusProgress.Visible = true;
                StatusText.Visible = true;
                StatusText.Text = string.Empty;
            }
            if (DirectoriesListView.InvokeRequired)
                DirectoriesListView.Invoke(new MethodInvoker(delegate { DirectoriesListView.Enabled = false; }));
            else
                DirectoriesListView.Enabled = false;
            if (FilterGroupBox.InvokeRequired)
                FilterGroupBox.Invoke(new MethodInvoker(delegate { FilterGroupBox.Enabled = false; }));
            else
                FilterGroupBox.Enabled = false;
        }

        private void AnalyzerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AnalyzerWorker_Prepare(sender, e);

            foreach (string path in this.Directories)
                this.DirSearch(path, FilterFileTypesTextBox.Text);

            FileImageList.Images.Clear();
            foreach(string hash in this.DuplicatedFilesMap.Keys)
            {
                if (AnalyzerWorker.CancellationPending)
                    break;
                List<string> duplicatedFiles = this.DuplicatedFilesMap[hash];
                if(duplicatedFiles.Count>1)
                {
                    if (ResultListView.InvokeRequired) {
                        ResultListView.Invoke(new MethodInvoker(delegate {
                            ListViewItem item = ResultListView.Items.Add(string.Format("{0}", ResultListView.Items.Count+1));
                            item.Tag = duplicatedFiles;
                            item.SubItems.Add(hash);
                            item.SubItems.Add(string.Format("{0}", duplicatedFiles.Count));
                        }));
                    }
                    else
                    {
                        ListViewItem item = ResultListView.Items.Add(string.Format("{0}", ResultListView.Items.Count + 1));
                        item.Tag = duplicatedFiles;
                        item.SubItems.Add(hash);
                        item.SubItems.Add(string.Format("{0}", duplicatedFiles.Count));
                    }
                }
            }
        }

        private void AnalyzerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void DirSearch(string sDir, string sExts)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir, sExts))
                {
                    if (AnalyzerWorker.CancellationPending)
                        break;
                    string hash = string.Empty;

                    if (StatusBar.InvokeRequired)
                        StatusBar.Invoke(new MethodInvoker(delegate { StatusText.Text = f; }));
                    else
                        StatusText.Text = f;

                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(f))
                        {
                            hash = BitConverter.ToString(md5.ComputeHash(stream));
                            if (!this.DuplicatedFilesMap.ContainsKey(hash)) {
                                List<string> duplicatedFiles = new List<string>();
                                duplicatedFiles.Add(f);
                                this.DuplicatedFilesMap[hash] = duplicatedFiles;
                            } else {
                                List<string> duplicatedFiles = this.DuplicatedFilesMap[hash];
                                if (!duplicatedFiles.Contains(f))
                                    duplicatedFiles.Add(f);
                            }
                        }
                    }                  
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    if (AnalyzerWorker.CancellationPending)
                        break;
                    this.DirSearch(d, sExts);
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void AnalyzerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (StartButton.InvokeRequired)
                StartButton.Invoke(new MethodInvoker(delegate { StartButton.Visible = true; }));
            else
                StartButton.Visible = true;
            if (StopButton.InvokeRequired)
                StopButton.Invoke(new MethodInvoker(delegate { StopButton.Visible = false; }));
            else
                StopButton.Visible = false;
            if (StatusBar.InvokeRequired)
                StatusBar.Invoke(new MethodInvoker(delegate {
                    StatusProgress.Visible = false;

                }));
            else
            {
                StatusProgress.Visible = false;
            }
            if (DirectoriesListView.InvokeRequired)
                DirectoriesListView.Invoke(new MethodInvoker(delegate { DirectoriesListView.Enabled = true; }));
            else
                DirectoriesListView.Enabled = true;
            if (FilterGroupBox.InvokeRequired)
                FilterGroupBox.Invoke(new MethodInvoker(delegate { FilterGroupBox.Enabled = true; }));
            else
                FilterGroupBox.Enabled = true;
        }

        private void ResultListView_DoubleClick(object sender, EventArgs e)
        {
            if (ResultListView.SelectedItems.Count <= 0)
                return;
            DuplicatedFileViewer fileViewer = new DuplicatedFileViewer(ResultListView.SelectedItems[0].Tag as List<string>);
            if (fileViewer.ShowDialog() != DialogResult.OK)
                return;
        }
        
    }
}
