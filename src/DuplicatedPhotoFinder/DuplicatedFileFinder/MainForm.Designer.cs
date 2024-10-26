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
            this.ResultListView = new System.Windows.Forms.ListView();
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
            this.directoriesListContextMenu.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // DirectoriesListView
            // 
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
            // ResultListView
            // 
            this.ResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.GridLines = true;
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(12, 232);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.ShowItemToolTips = true;
            this.ResultListView.Size = new System.Drawing.Size(657, 304);
            this.ResultListView.TabIndex = 4;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Details;
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
            this.label4.Location = new System.Drawing.Point(13, 213);
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
            this.StatusText.AutoSize = false;
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(891, 17);
            this.StatusText.Spring = true;
            this.StatusText.Visible = false;
            // 
            // StatusProgress
            // 
            this.StatusProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusProgress.Name = "StatusProgress";
            this.StatusProgress.Size = new System.Drawing.Size(100, 16);
            this.StatusProgress.Visible = false;
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Enabled = false;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.ResultListView);
            this.Controls.Add(this.DirectoriesListView);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
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
        private System.Windows.Forms.ListView ResultListView;
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
    }
}