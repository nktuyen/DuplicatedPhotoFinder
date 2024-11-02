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
using Microsoft.VisualBasic.FileIO;

namespace DuplicatedFileFinder
{
    public delegate void DirectoryListChange(EventArgs e);
    public partial class MainForm : Form
    {
        private readonly List<string> Directories = new List<string>();
        private readonly Dictionary<string, List<string>> DuplicatedFilesMap = new Dictionary<string, List<string>>();
        private readonly Dictionary<Control, bool> ControlEnableState = new Dictionary<Control, bool>();

        private event DirectoryListChange DirectoryListChanged;
        private  Stopwatch Stopwatch { get; set; } = new Stopwatch();
        private CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

        enum KeepStrategy
        {
            KeepFirstFile=0,
            KeepLastFile=1,
            KeepOldestFile=2,
            KeepNewestFile=3
        };
        enum DeletionStrategy
        {
            MoveToTrash=0,
            PermanentDelete=1,
            MoveToSpecifiedDirectory=2
        };

        private KeepStrategy KeepOption { get; set; } = MainForm.KeepStrategy.KeepFirstFile;
        private DeletionStrategy DeletionOption { get; set; } = DeletionStrategy.MoveToTrash;
        private string SpecifiedMovedDirectory { get; set; } = string.Empty;

        public MainForm()
        {
            InitializeComponent();

            DirectoryListChanged += new DirectoryListChange(OnDirectoriesListChanged);
        }

        private void ControlEnableSet(Control ctrl, bool enable)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    ControlEnableState[ctrl] = ctrl.Enabled;
                    ctrl.Enabled = enable;
                }));
            }
            else {
                ControlEnableState[ctrl] = ctrl.Enabled;
                ctrl.Enabled = enable;
            }
        }

        private void ControlEnableRestore(Control ctrl)
        {
            ctrl.Enabled = ControlEnableState[ctrl];
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
            DirectoryBrowserDialog.ShowNewFolderButton = false;
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
            ResultListView.Items.Clear();
            ResolveButton.Enabled = ResultListView.Items.Count > 0;
            foreach(ListViewItem item in DirectoriesListView.Items)
            {
                this.Directories.Add(item.SubItems[1].Text);
            }
            this.CancellationTokenSource = new CancellationTokenSource();
            AnalyzerWorker.RunWorkerAsync(this.Directories);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (AnalyzerWorker.IsBusy)
                AnalyzerWorker.CancelAsync();
            if (!this.CancellationTokenSource.IsCancellationRequested)
                this.CancellationTokenSource.Cancel();
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
                    StatusProgress.Maximum = 100;
                    StatusProgress.Style = ProgressBarStyle.Marquee;
                    StatusProgress.Visible = true;
                    StatusText.Visible = true;
                    StatusText.Text = string.Empty;
                }));
            else
            {
                StatusProgress.Maximum = 100;
                StatusProgress.Style = ProgressBarStyle.Marquee;
                StatusProgress.Visible = true;
                StatusText.Visible = true;
                StatusText.Text = string.Empty;
            }

            ControlEnableSet(DirectoriesListView, false);
            ControlEnableSet(ResultListView, false);
            ControlEnableSet(FilterGroupBox, false);
            ControlEnableSet(ResolveButton, false);
            ControlEnableSet(StrategyGroupbox, false);
        }

        private void AnalyzerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Stopwatch.Start();
            AnalyzerWorker_Prepare(sender, e);

            foreach (string path in this.Directories)
                this.DirSearchAsync(path, FilterFileTypesTextBox.Text);

            foreach(string hash in this.DuplicatedFilesMap.Keys)
            {
                if (AnalyzerWorker.CancellationPending)
                    break;
                List<string> duplicatedFiles = this.DuplicatedFilesMap[hash];
                if(duplicatedFiles.Count > 1)
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
                if (ResolveButton.InvokeRequired)
                {
                    ResolveButton.Invoke(new MethodInvoker(delegate { ResolveButton.Enabled = ResultListView.Items.Count > 0; }));
                }
                else
                {
                    ResolveButton.Enabled = ResultListView.Items.Count > 0;
                }
            }
        }

        private void AnalyzerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private string CalcMD5(string file, CancellationToken cancellationToken)
        {
            Debug.Print(file);
            using (var stream = File.OpenRead(file))
            using (var md5 = MD5.Create())
            {
                const int blockSize = 1024 * 1024 * 4;
                var buffer = new byte[blockSize];
                long offset = 0;

                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var read = stream.Read(buffer, 0, blockSize);
                    if (stream.Position == stream.Length)
                    {
                        md5.TransformFinalBlock(buffer, 0, read);
                        break;
                    }
                    offset += md5.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
                }
                return System.BitConverter.ToString(md5.Hash).Replace("-", "");
            }
        }

        private void DirSearchAsync(string sDir, string sExts)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir, sExts))
                {
                    if (AnalyzerWorker.CancellationPending)
                        break;

                    if (StatusBar.InvokeRequired)
                        StatusBar.Invoke(new MethodInvoker(delegate { StatusText.Text = f; }));
                    else
                        StatusText.Text = f;

                    string hash = CalcMD5(f, this.CancellationTokenSource.Token);

                    if (!this.DuplicatedFilesMap.ContainsKey(hash))
                    {
                        List<string> duplicatedFiles = new List<string>();
                        duplicatedFiles.Add(f);
                        this.DuplicatedFilesMap[hash] = duplicatedFiles;
                    }
                    else
                    {
                        List<string> duplicatedFiles = this.DuplicatedFilesMap[hash];
                        if (!duplicatedFiles.Contains(f))
                            duplicatedFiles.Add(f);
                    }
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    if (AnalyzerWorker.CancellationPending)
                        break;
                    this.DirSearchAsync(d, sExts);
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
                    StatusText.Text = string.Empty;

                }));
            else
            {
                StatusProgress.Visible = false;
                StatusText.Text = string.Empty;
            }

            ControlEnableRestore(DirectoriesListView);
            ControlEnableRestore(ResultListView);
            ControlEnableRestore(FilterGroupBox);
            ControlEnableRestore(StrategyGroupbox);
            ControlEnableSet(ResolveButton, this.DuplicatedFilesMap.Count > 0);
            this.Stopwatch.Stop();
            if(!e.Cancelled)
                MessageBox.Show(string.Format("Elapsed time:{0} ms", this.Stopwatch.ElapsedMilliseconds));
        }

        private void ResultListView_DoubleClick(object sender, EventArgs e)
        {
            if (ResultListView.SelectedItems.Count <= 0)
                return;
            DuplicatedFileViewer fileViewer = new DuplicatedFileViewer(ResultListView.SelectedItems[0].Tag as List<string>);
            if (fileViewer.ShowDialog() != DialogResult.OK)
                return;
            ListViewItem selItem = ResultListView.SelectedItems[0] as ListViewItem;
            selItem.SubItems[2].Text = string.Format("{0}", fileViewer.Files.Count);
        }

        private void ResultListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ResultListView_DoubleClick(sender, e);
            }
        }

        private void DirectoriesListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void DirectoriesListView_DragDrop(object sender, DragEventArgs e)
        {
            string[] handles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach(string path in handles)
            {
                if (Directory.Exists(path)) {
                    ListViewItem item = null;
                    for (int i = 0; i < DirectoriesListView.Items.Count; i++)
                    {
                        item = DirectoriesListView.Items[i] as ListViewItem;
                        if (string.Compare(item.SubItems[1].Text, path, true) == 0)
                        {
                            MessageBox.Show("Directory is already in the list\n"+ path, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    item = DirectoriesListView.Items.Add(string.Format("{0}", DirectoriesListView.Items.Count + 1));
                    item.SubItems.Add(path);
                    DirectoryListChanged?.Invoke(new EventArgs());
                }
            }
        }

        private void ResolveButton_Click(object sender, EventArgs e)
        {
            if (KeepFirstFileOption.Checked)
                this.KeepOption = KeepStrategy.KeepFirstFile;
            else if (KeepLastFileOption.Checked)
                this.KeepOption = KeepStrategy.KeepLastFile;
            else if (KeepOldestFileOption.Checked)
                this.KeepOption = KeepStrategy.KeepOldestFile;
            else if (KeepNewestFileOption.Checked)
                this.KeepOption = KeepStrategy.KeepNewestFile;

            if (MoveToTrashOption.Checked)
                this.DeletionOption = DeletionStrategy.MoveToTrash;
            else if (PermanentDeleteOption.Checked)
                this.DeletionOption = DeletionStrategy.PermanentDelete;
            else if (MoveToSpecifiedDirOption.Checked)
            {
                this.DeletionOption = DeletionStrategy.MoveToSpecifiedDirectory;
                if (this.SpecifiedMovedDirectory == string.Empty)
                {
                    MessageBox.Show("Destination directory is not specified", "Move to specified directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ResolverWorker.RunWorkerAsync(this.DuplicatedFilesMap);
        }

        private void ResolverWorker_Prepare(object sender, DoWorkEventArgs e)
        {
            if (StatusBar.InvokeRequired)
                StatusBar.Invoke(new MethodInvoker(delegate {
                    StatusProgress.Maximum = ResultListView.Items.Count;
                    StatusProgress.Style = ProgressBarStyle.Continuous;
                    StatusProgress.Visible = true;
                    StatusText.Visible = true;
                    StatusText.Text = string.Empty;
                }));
            else
            {
                StatusProgress.Maximum = ResultListView.Items.Count;
                StatusProgress.Style = ProgressBarStyle.Continuous;
                StatusProgress.Visible = true;
                StatusText.Visible = true;
                StatusText.Text = string.Empty;
            }

            if (ResolveButton.InvokeRequired)
            {
                ResolveButton.Invoke(new MethodInvoker(delegate
                {
                    ResolveButton.Visible = false;
                }));
            }
            else
            {
                ResolveButton.Visible = false;
            }

            if (ResolveCancelButton.InvokeRequired)
            {
                ResolveCancelButton.Invoke(new MethodInvoker(delegate
                {
                    ResolveCancelButton.Visible = true;
                }));
            }
            else
            {
                ResolveCancelButton.Visible = true;
            }

            ControlEnableSet(DirectoriesListView, false);
            ControlEnableSet(FilterGroupBox, false);
            ControlEnableSet(StrategyGroupbox, false);
            ControlEnableSet(StartButton, false);
            ControlEnableSet(ResultListView, false);
        }

        private void ResolverWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Stopwatch.Start();
            ResolverWorker_Prepare(sender, e);

            for(int i = 0; i < ResultListView.Items.Count; i++)
            {
                if (ResolverWorker.CancellationPending)
                    break;

                List<string> duplicatedFiles = null;
                string hash = string.Empty;
                DateTime oldestTime = new DateTime();
                DateTime newestTime = new DateTime();

                if (ResultListView.InvokeRequired)
                {
                    ResultListView.Invoke(new MethodInvoker(delegate
                    {
                        duplicatedFiles = ResultListView.Items[i].Tag as List<string>;
                        hash = ResultListView.Items[i].SubItems[1].Text;
                    }));
                }
                else
                {
                    duplicatedFiles = ResultListView.Items[i].Tag as List<string>;
                    hash = ResultListView.Items[i].SubItems[1].Text;
                }

                for (int j = 0; j < duplicatedFiles.Count; j++)
                {
                    DateTime fileCreateTime = File.GetCreationTime(duplicatedFiles[j]);
                    if (j == 0)
                    {
                        oldestTime = fileCreateTime;
                        newestTime = fileCreateTime;
                    }
                    else
                    {
                        if (fileCreateTime < oldestTime)
                            oldestTime = fileCreateTime;

                        if (fileCreateTime > newestTime)
                            newestTime = fileCreateTime;
                    }
                }

                for (int j = 0; j < duplicatedFiles.Count; j++)
                {
                    if (StatusBar.InvokeRequired)
                    {
                        StatusBar.Invoke(new MethodInvoker(delegate
                        {
                            StatusText.Text = duplicatedFiles[j];
                        }));
                    }
                    else
                    {
                        StatusText.Text = duplicatedFiles[j];
                    }

                    DateTime fileCreateTime = File.GetCreationTime(duplicatedFiles[j]);
                    if ((this.KeepOption == KeepStrategy.KeepFirstFile && j > 0) 
                        || (this.KeepOption == KeepStrategy.KeepLastFile && j < (duplicatedFiles.Count-1))
                        || (this.KeepOption == KeepStrategy.KeepOldestFile && fileCreateTime > oldestTime)
                        || (this.KeepOption == KeepStrategy.KeepNewestFile && fileCreateTime < newestTime))
                    {
                        if (this.DeletionOption == DeletionStrategy.MoveToTrash)
                        {
                            try
                            {
                                FileSystem.DeleteFile(duplicatedFiles[j], UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }
                            catch (Exception ex)
                            {
                                Debug.Print(ex.Message);
                            }
                        }
                        else if (this.DeletionOption == DeletionStrategy.PermanentDelete)
                        {
                            try
                            {
                                File.Delete(duplicatedFiles[j]);
                            }
                            catch (Exception ex)
                            {
                                Debug.Print(ex.Message);
                            }
                        }
                        else if (this.DeletionOption == DeletionStrategy.MoveToSpecifiedDirectory)
                        {
                            string destinationMoveDir = this.SpecifiedMovedDirectory + "\\" + hash;
                            if (!Directory.Exists(destinationMoveDir))
                            {
                                try
                                {
                                    Directory.CreateDirectory(destinationMoveDir);
                                }
                                catch (Exception ex1)
                                {
                                    Debug.Print(ex1.Message);
                                }
                            }

                            FileInfo fi = new FileInfo(duplicatedFiles[j]);
                            string destinationMoveFilename = destinationMoveDir + "\\" + fi.Name;
                            try
                            {
                                File.Move(duplicatedFiles[j], destinationMoveFilename);
                            }
                            catch (Exception ex2)
                            {
                                Debug.Print(ex2.Message);
                            }
                        }
                    }
                }

                for (int k = duplicatedFiles.Count-1;k >= 0; k--)
                {
                    if (!File.Exists(duplicatedFiles[k]))
                        duplicatedFiles.RemoveAt(k);
                }

                if (ResultListView.InvokeRequired)
                {
                    ResultListView.Invoke(new MethodInvoker(delegate
                    {
                        ListViewItem selItem = ResultListView.Items[i] as ListViewItem;
                        selItem.SubItems[2].Text = string.Format("{0}", duplicatedFiles.Count);
                    }));
                }
                else
                {
                    ListViewItem selItem = ResultListView.Items[i] as ListViewItem;
                    selItem.SubItems[2].Text = string.Format("{0}", duplicatedFiles.Count);
                }
            }

        }

        private void ResolverWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (StatusBar.InvokeRequired)
            {
                StatusBar.Invoke(new MethodInvoker(delegate
                {
                    StatusProgress.Value = e.ProgressPercentage;
                }));
            }
            else
            {
                StatusProgress.Value = e.ProgressPercentage;
            }
        }

        private void ResolverWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (StatusBar.InvokeRequired)
                StatusBar.Invoke(new MethodInvoker(delegate {
                    StatusProgress.Visible = false;
                    StatusText.Visible = false;
                    StatusText.Text = string.Empty;
                }));
            else
            {
                StatusProgress.Visible = false;
                StatusText.Visible = false;
                StatusText.Text = string.Empty;
            }

            if (ResolveButton.InvokeRequired)
            {
                ResolveButton.Invoke(new MethodInvoker(delegate
                {
                    ResolveButton.Visible = true;
                }));
            }
            else
            {
                ResolveButton.Visible = true;
            }

            if (ResolveCancelButton.InvokeRequired)
            {
                ResolveCancelButton.Invoke(new MethodInvoker(delegate
                {
                    ResolveCancelButton.Visible = false;
                }));
            }
            else
            {
                ResolveCancelButton.Visible = false;
            }

            ControlEnableRestore(DirectoriesListView);
            ControlEnableRestore(FilterGroupBox );
            ControlEnableRestore(StrategyGroupbox);
            ControlEnableRestore(StartButton);
            ControlEnableRestore(ResultListView);
            this.Stopwatch.Stop();
            if(!e.Cancelled)
                MessageBox.Show(string.Format("Elapsed time:{0} ms", this.Stopwatch.ElapsedMilliseconds));
        }

        private void ResolveCancelButton_Click(object sender, EventArgs e)
        {
            if (ResolverWorker.IsBusy)
                ResolverWorker.CancelAsync();
        }

        private void BrowseSpecifiedDirButton_Click(object sender, EventArgs e)
        {
            DirectoryBrowserDialog.ShowNewFolderButton = true;
            if (DirectoryBrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            MoveToSpecifiedDirOption.Checked = true;
            this.SpecifiedMovedDirectory = DirectoryBrowserDialog.SelectedPath;
            SpecifiedMoveToPathLabel.Text = this.SpecifiedMovedDirectory;
        }

        private void MoveToSpecifiedDirOption_Click(object sender, EventArgs e)
        {
            if (this.SpecifiedMovedDirectory == string.Empty)
            {
                BrowseSpecifiedDirButton_Click(sender, e);
            }
        }

        private void ResultListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
