namespace DuplicatedFileFinder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DirectoriesListView = new System.Windows.Forms.ListView();
            this.colOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.directoriesListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveAllDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DirectoryBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.StartButton = new System.Windows.Forms.Button();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.FilterSizeUnitCombo = new System.Windows.Forms.ComboBox();
            this.FilterSizeValueTextBox = new System.Windows.Forms.TextBox();
            this.FilterSizeTypeCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilterFileTypesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.StopButton = new System.Windows.Forms.Button();
            this.AnalyzerWorker = new System.ComponentModel.BackgroundWorker();
            this.FileImageList = new System.Windows.Forms.ImageList(this.components);
            this.ResolveButton = new System.Windows.Forms.Button();
            this.ResolverWorker = new System.ComponentModel.BackgroundWorker();
            this.ResolveCancelButton = new System.Windows.Forms.Button();
            this.StrategyGroupbox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SpecifiedMoveToPathLabel = new System.Windows.Forms.Label();
            this.BrowseSpecifiedDirButton = new System.Windows.Forms.Button();
            this.MoveToSpecifiedDirOption = new System.Windows.Forms.RadioButton();
            this.PermanentDeleteOption = new System.Windows.Forms.RadioButton();
            this.MoveToTrashOption = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.KeepLastFileOption = new System.Windows.Forms.RadioButton();
            this.KeepFirstFileOption = new System.Windows.Forms.RadioButton();
            this.KeepOldestFileOption = new System.Windows.Forms.RadioButton();
            this.KeepNewestFileOption = new System.Windows.Forms.RadioButton();
            this.ResultListView = new DuplicatedFileFinder.ListViewEx();
            this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuplicatedCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.directoriesListContextMenu.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.StrategyGroupbox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoriesListView
            // 
            this.DirectoriesListView.AllowDrop = true;
            this.DirectoriesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoriesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrder,
            this.colPath});
            this.DirectoriesListView.ContextMenuStrip = this.directoriesListContextMenu;
            this.DirectoriesListView.FullRowSelect = true;
            this.DirectoriesListView.GridLines = true;
            this.DirectoriesListView.HideSelection = false;
            this.DirectoriesListView.Location = new System.Drawing.Point(12, 24);
            this.DirectoriesListView.MultiSelect = false;
            this.DirectoriesListView.Name = "DirectoriesListView";
            this.DirectoriesListView.ShowItemToolTips = true;
            this.DirectoriesListView.Size = new System.Drawing.Size(658, 102);
            this.DirectoriesListView.TabIndex = 0;
            this.DirectoriesListView.UseCompatibleStateImageBehavior = false;
            this.DirectoriesListView.View = System.Windows.Forms.View.Details;
            this.DirectoriesListView.ItemActivate += new System.EventHandler(this.DirectoriesListView_ItemActivate);
            this.DirectoriesListView.SelectedIndexChanged += new System.EventHandler(this.DirectoriesListView_SelectedIndexChanged);
            this.DirectoriesListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirectoriesListView_DragDrop);
            this.DirectoriesListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.DirectoriesListView_DragEnter);
            // 
            // colOrder
            // 
            this.colOrder.Text = "#";
            this.colOrder.Width = 40;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 800;
            // 
            // directoriesListContextMenu
            // 
            this.directoriesListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDirectoryMenuItem,
            this.RemoveDirectoryMenuItem,
            this.RemoveAllDirectoryMenuItem});
            this.directoriesListContextMenu.Name = "directoriesListContextMenu";
            this.directoriesListContextMenu.Size = new System.Drawing.Size(135, 70);
            this.directoriesListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.directoriesListContextMenu_Opening);
            // 
            // AddDirectoryMenuItem
            // 
            this.AddDirectoryMenuItem.Name = "AddDirectoryMenuItem";
            this.AddDirectoryMenuItem.Size = new System.Drawing.Size(134, 22);
            this.AddDirectoryMenuItem.Text = "Add";
            this.AddDirectoryMenuItem.Click += new System.EventHandler(this.AddDirectoryMenuItem_Click);
            // 
            // RemoveDirectoryMenuItem
            // 
            this.RemoveDirectoryMenuItem.Enabled = false;
            this.RemoveDirectoryMenuItem.Name = "RemoveDirectoryMenuItem";
            this.RemoveDirectoryMenuItem.Size = new System.Drawing.Size(134, 22);
            this.RemoveDirectoryMenuItem.Text = "Remove";
            this.RemoveDirectoryMenuItem.Click += new System.EventHandler(this.RemoveDirectoryMenuItem_Click);
            // 
            // RemoveAllDirectoryMenuItem
            // 
            this.RemoveAllDirectoryMenuItem.Enabled = false;
            this.RemoveAllDirectoryMenuItem.Name = "RemoveAllDirectoryMenuItem";
            this.RemoveAllDirectoryMenuItem.Size = new System.Drawing.Size(134, 22);
            this.RemoveAllDirectoryMenuItem.Text = "Remove All";
            this.RemoveAllDirectoryMenuItem.Click += new System.EventHandler(this.RemoveAllDirectoryMenuItem_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Enabled = false;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(676, 24);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(96, 102);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "&Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterGroupBox.Controls.Add(this.FilterSizeUnitCombo);
            this.FilterGroupBox.Controls.Add(this.FilterSizeValueTextBox);
            this.FilterGroupBox.Controls.Add(this.FilterSizeTypeCombo);
            this.FilterGroupBox.Controls.Add(this.label2);
            this.FilterGroupBox.Controls.Add(this.FilterFileTypesTextBox);
            this.FilterGroupBox.Controls.Add(this.label1);
            this.FilterGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterGroupBox.Location = new System.Drawing.Point(12, 133);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(658, 60);
            this.FilterGroupBox.TabIndex = 5;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter";
            // 
            // FilterSizeUnitCombo
            // 
            this.FilterSizeUnitCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterSizeUnitCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterSizeUnitCombo.FormattingEnabled = true;
            this.FilterSizeUnitCombo.Items.AddRange(new object[] {
            "Byte(s)",
            "KB",
            "MB",
            "GB",
            "TB",
            "PB"});
            this.FilterSizeUnitCombo.Location = new System.Drawing.Point(582, 22);
            this.FilterSizeUnitCombo.Name = "FilterSizeUnitCombo";
            this.FilterSizeUnitCombo.Size = new System.Drawing.Size(60, 23);
            this.FilterSizeUnitCombo.TabIndex = 5;
            this.FilterSizeUnitCombo.Visible = false;
            this.FilterSizeUnitCombo.SelectedIndexChanged += new System.EventHandler(this.FilterSizeUnitCombo_SelectedIndexChanged);
            // 
            // FilterSizeValueTextBox
            // 
            this.FilterSizeValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterSizeValueTextBox.Location = new System.Drawing.Point(480, 23);
            this.FilterSizeValueTextBox.Name = "FilterSizeValueTextBox";
            this.FilterSizeValueTextBox.Size = new System.Drawing.Size(100, 21);
            this.FilterSizeValueTextBox.TabIndex = 4;
            this.FilterSizeValueTextBox.Text = "0";
            this.FilterSizeValueTextBox.Visible = false;
            this.FilterSizeValueTextBox.TextChanged += new System.EventHandler(this.FilterSizeValueTextBox_TextChanged);
            this.FilterSizeValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterSizeValueTextBox_KeyPress);
            // 
            // FilterSizeTypeCombo
            // 
            this.FilterSizeTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterSizeTypeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterSizeTypeCombo.FormattingEnabled = true;
            this.FilterSizeTypeCombo.Items.AddRange(new object[] {
            "Any",
            "Equal",
            "Less Than",
            "Greater Than"});
            this.FilterSizeTypeCombo.Location = new System.Drawing.Point(357, 22);
            this.FilterSizeTypeCombo.Name = "FilterSizeTypeCombo";
            this.FilterSizeTypeCombo.Size = new System.Drawing.Size(121, 23);
            this.FilterSizeTypeCombo.TabIndex = 3;
            this.FilterSizeTypeCombo.SelectedIndexChanged += new System.EventHandler(this.FilterSizeTypeCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size:";
            // 
            // FilterFileTypesTextBox
            // 
            this.FilterFileTypesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterFileTypesTextBox.Location = new System.Drawing.Point(89, 23);
            this.FilterFileTypesTextBox.Name = "FilterFileTypesTextBox";
            this.FilterFileTypesTextBox.Size = new System.Drawing.Size(200, 21);
            this.FilterFileTypesTextBox.TabIndex = 1;
            this.FilterFileTypesTextBox.Text = "*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Types:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Directories:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duplicated Items:";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText,
            this.StatusProgress});
            this.StatusBar.Location = new System.Drawing.Point(0, 539);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 8;
            // 
            // StatusText
            // 
            this.StatusText.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(759, 17);
            this.StatusText.Spring = true;
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusProgress
            // 
            this.StatusProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusProgress.Name = "StatusProgress";
            this.StatusProgress.Size = new System.Drawing.Size(100, 16);
            this.StatusProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.StatusProgress.Visible = false;
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Location = new System.Drawing.Point(676, 24);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(96, 102);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "&Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // AnalyzerWorker
            // 
            this.AnalyzerWorker.WorkerReportsProgress = true;
            this.AnalyzerWorker.WorkerSupportsCancellation = true;
            this.AnalyzerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AnalyzerWorker_DoWork);
            this.AnalyzerWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AnalyzerWorker_ProgressChanged);
            this.AnalyzerWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AnalyzerWorker_RunWorkerCompleted);
            // 
            // FileImageList
            // 
            this.FileImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.FileImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.FileImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ResolveButton
            // 
            this.ResolveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResolveButton.Enabled = false;
            this.ResolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResolveButton.Location = new System.Drawing.Point(675, 298);
            this.ResolveButton.Name = "ResolveButton";
            this.ResolveButton.Size = new System.Drawing.Size(96, 88);
            this.ResolveButton.TabIndex = 10;
            this.ResolveButton.Text = "Resolve";
            this.ResolveButton.UseVisualStyleBackColor = true;
            this.ResolveButton.Click += new System.EventHandler(this.ResolveButton_Click);
            // 
            // ResolverWorker
            // 
            this.ResolverWorker.WorkerReportsProgress = true;
            this.ResolverWorker.WorkerSupportsCancellation = true;
            this.ResolverWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ResolverWorker_DoWork);
            this.ResolverWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ResolverWorker_ProgressChanged);
            this.ResolverWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ResolverWorker_RunWorkerCompleted);
            // 
            // ResolveCancelButton
            // 
            this.ResolveCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResolveCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResolveCancelButton.Location = new System.Drawing.Point(675, 298);
            this.ResolveCancelButton.Name = "ResolveCancelButton";
            this.ResolveCancelButton.Size = new System.Drawing.Size(96, 88);
            this.ResolveCancelButton.TabIndex = 11;
            this.ResolveCancelButton.Text = "&Cancel";
            this.ResolveCancelButton.UseVisualStyleBackColor = true;
            this.ResolveCancelButton.Visible = false;
            this.ResolveCancelButton.Click += new System.EventHandler(this.ResolveCancelButton_Click);
            // 
            // StrategyGroupbox
            // 
            this.StrategyGroupbox.Controls.Add(this.groupBox2);
            this.StrategyGroupbox.Controls.Add(this.groupBox1);
            this.StrategyGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrategyGroupbox.Location = new System.Drawing.Point(15, 210);
            this.StrategyGroupbox.Name = "StrategyGroupbox";
            this.StrategyGroupbox.Size = new System.Drawing.Size(654, 87);
            this.StrategyGroupbox.TabIndex = 12;
            this.StrategyGroupbox.TabStop = false;
            this.StrategyGroupbox.Text = " Strategy";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SpecifiedMoveToPathLabel);
            this.groupBox2.Controls.Add(this.BrowseSpecifiedDirButton);
            this.groupBox2.Controls.Add(this.MoveToSpecifiedDirOption);
            this.groupBox2.Controls.Add(this.PermanentDeleteOption);
            this.groupBox2.Controls.Add(this.MoveToTrashOption);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(235, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deletion";
            // 
            // SpecifiedMoveToPathLabel
            // 
            this.SpecifiedMoveToPathLabel.AutoEllipsis = true;
            this.SpecifiedMoveToPathLabel.Location = new System.Drawing.Point(257, 17);
            this.SpecifiedMoveToPathLabel.Name = "SpecifiedMoveToPathLabel";
            this.SpecifiedMoveToPathLabel.Size = new System.Drawing.Size(130, 15);
            this.SpecifiedMoveToPathLabel.TabIndex = 2;
            this.SpecifiedMoveToPathLabel.Text = "specified directory";
            // 
            // BrowseSpecifiedDirButton
            // 
            this.BrowseSpecifiedDirButton.Location = new System.Drawing.Point(387, 12);
            this.BrowseSpecifiedDirButton.Name = "BrowseSpecifiedDirButton";
            this.BrowseSpecifiedDirButton.Size = new System.Drawing.Size(24, 23);
            this.BrowseSpecifiedDirButton.TabIndex = 1;
            this.BrowseSpecifiedDirButton.Text = "...";
            this.BrowseSpecifiedDirButton.UseVisualStyleBackColor = true;
            this.BrowseSpecifiedDirButton.Click += new System.EventHandler(this.BrowseSpecifiedDirButton_Click);
            // 
            // MoveToSpecifiedDirOption
            // 
            this.MoveToSpecifiedDirOption.AutoSize = true;
            this.MoveToSpecifiedDirOption.Location = new System.Drawing.Point(194, 15);
            this.MoveToSpecifiedDirOption.Name = "MoveToSpecifiedDirOption";
            this.MoveToSpecifiedDirOption.Size = new System.Drawing.Size(68, 19);
            this.MoveToSpecifiedDirOption.TabIndex = 0;
            this.MoveToSpecifiedDirOption.Text = "Move to";
            this.MoveToSpecifiedDirOption.UseVisualStyleBackColor = true;
            this.MoveToSpecifiedDirOption.Click += new System.EventHandler(this.MoveToSpecifiedDirOption_Click);
            // 
            // PermanentDeleteOption
            // 
            this.PermanentDeleteOption.AutoSize = true;
            this.PermanentDeleteOption.Location = new System.Drawing.Point(127, 15);
            this.PermanentDeleteOption.Name = "PermanentDeleteOption";
            this.PermanentDeleteOption.Size = new System.Drawing.Size(61, 19);
            this.PermanentDeleteOption.TabIndex = 0;
            this.PermanentDeleteOption.Text = "Delete";
            this.PermanentDeleteOption.UseVisualStyleBackColor = true;
            // 
            // MoveToTrashOption
            // 
            this.MoveToTrashOption.AutoSize = true;
            this.MoveToTrashOption.Checked = true;
            this.MoveToTrashOption.Location = new System.Drawing.Point(19, 15);
            this.MoveToTrashOption.Name = "MoveToTrashOption";
            this.MoveToTrashOption.Size = new System.Drawing.Size(102, 19);
            this.MoveToTrashOption.TabIndex = 0;
            this.MoveToTrashOption.TabStop = true;
            this.MoveToTrashOption.Text = "Move to Trash";
            this.MoveToTrashOption.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.KeepNewestFileOption);
            this.groupBox1.Controls.Add(this.KeepOldestFileOption);
            this.groupBox1.Controls.Add(this.KeepLastFileOption);
            this.groupBox1.Controls.Add(this.KeepFirstFileOption);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(43, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keep";
            // 
            // KeepLastFileOption
            // 
            this.KeepLastFileOption.AutoSize = true;
            this.KeepLastFileOption.Location = new System.Drawing.Point(100, 15);
            this.KeepLastFileOption.Name = "KeepLastFileOption";
            this.KeepLastFileOption.Size = new System.Drawing.Size(67, 19);
            this.KeepLastFileOption.TabIndex = 0;
            this.KeepLastFileOption.Text = "Last file";
            this.KeepLastFileOption.UseVisualStyleBackColor = true;
            // 
            // KeepFirstFileOption
            // 
            this.KeepFirstFileOption.AutoSize = true;
            this.KeepFirstFileOption.Checked = true;
            this.KeepFirstFileOption.Location = new System.Drawing.Point(19, 15);
            this.KeepFirstFileOption.Name = "KeepFirstFileOption";
            this.KeepFirstFileOption.Size = new System.Drawing.Size(67, 19);
            this.KeepFirstFileOption.TabIndex = 0;
            this.KeepFirstFileOption.TabStop = true;
            this.KeepFirstFileOption.Text = "First file";
            this.KeepFirstFileOption.UseVisualStyleBackColor = true;
            // 
            // KeepOldestFileOption
            // 
            this.KeepOldestFileOption.AutoSize = true;
            this.KeepOldestFileOption.Location = new System.Drawing.Point(19, 36);
            this.KeepOldestFileOption.Name = "KeepOldestFileOption";
            this.KeepOldestFileOption.Size = new System.Drawing.Size(79, 19);
            this.KeepOldestFileOption.TabIndex = 0;
            this.KeepOldestFileOption.Text = "Oldest file";
            this.KeepOldestFileOption.UseVisualStyleBackColor = true;
            // 
            // KeepNewestFileOption
            // 
            this.KeepNewestFileOption.AutoSize = true;
            this.KeepNewestFileOption.Location = new System.Drawing.Point(100, 36);
            this.KeepNewestFileOption.Name = "KeepNewestFileOption";
            this.KeepNewestFileOption.Size = new System.Drawing.Size(85, 19);
            this.KeepNewestFileOption.TabIndex = 0;
            this.KeepNewestFileOption.Text = "Newest file";
            this.KeepNewestFileOption.UseVisualStyleBackColor = true;
            // 
            // ResultListView
            // 
            this.ResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListView.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colItem,
            this.colDuplicatedCount});
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.GridLines = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.LargeImageList = this.FileImageList;
            this.ResultListView.Location = new System.Drawing.Point(12, 318);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.ShowItemToolTips = true;
            this.ResultListView.Size = new System.Drawing.Size(657, 218);
            this.ResultListView.SmallImageList = this.FileImageList;
            this.ResultListView.TabIndex = 4;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
            this.ResultListView.SelectedIndexChanged += new System.EventHandler(this.ResultListView_SelectedIndexChanged);
            this.ResultListView.DoubleClick += new System.EventHandler(this.ResultListView_DoubleClick);
            this.ResultListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ResultListView_KeyUp);
            // 
            // colIndex
            // 
            this.colIndex.Text = "#";
            this.colIndex.Width = 40;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 480;
            // 
            // colDuplicatedCount
            // 
            this.colDuplicatedCount.Text = "Duplicated Count";
            this.colDuplicatedCount.Width = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.StrategyGroupbox);
            this.Controls.Add(this.ResolveButton);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.DirectoriesListView);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.ResolveCancelButton);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DuplicatedFileFinder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.directoriesListContextMenu.ResumeLayout(false);
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.StrategyGroupbox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DirectoriesListView;
        private System.Windows.Forms.ColumnHeader colOrder;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ContextMenuStrip directoriesListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddDirectoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveDirectoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveAllDirectoryMenuItem;
        private System.Windows.Forms.FolderBrowserDialog DirectoryBrowserDialog;
        private System.Windows.Forms.Button StartButton;
        private  ListViewEx ResultListView;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.TextBox FilterFileTypesTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FilterSizeUnitCombo;
        private System.Windows.Forms.TextBox FilterSizeValueTextBox;
        private System.Windows.Forms.ComboBox FilterSizeTypeCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripProgressBar StatusProgress;
        private System.Windows.Forms.Button StopButton;
        private System.ComponentModel.BackgroundWorker AnalyzerWorker;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colDuplicatedCount;
        private System.Windows.Forms.ImageList FileImageList;
        private System.Windows.Forms.Button ResolveButton;
        private System.ComponentModel.BackgroundWorker ResolverWorker;
        private System.Windows.Forms.Button ResolveCancelButton;
        private System.Windows.Forms.GroupBox StrategyGroupbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton KeepLastFileOption;
        private System.Windows.Forms.RadioButton KeepFirstFileOption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label SpecifiedMoveToPathLabel;
        private System.Windows.Forms.Button BrowseSpecifiedDirButton;
        private System.Windows.Forms.RadioButton MoveToSpecifiedDirOption;
        private System.Windows.Forms.RadioButton PermanentDeleteOption;
        private System.Windows.Forms.RadioButton MoveToTrashOption;
        private System.Windows.Forms.RadioButton KeepNewestFileOption;
        private System.Windows.Forms.RadioButton KeepOldestFileOption;
    }
}