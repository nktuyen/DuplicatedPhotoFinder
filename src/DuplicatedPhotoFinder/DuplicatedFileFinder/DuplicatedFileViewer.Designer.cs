namespace DuplicatedFileFinder
{
    partial class DuplicatedFileViewer
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
            this.PreviewPicture = new System.Windows.Forms.PictureBox();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.FilePreviewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FilePreviewOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePreviewShowInFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePreviewMoveToTrashMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilePreviewDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture)).BeginInit();
            this.FilePreviewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PreviewPicture
            // 
            this.PreviewPicture.Location = new System.Drawing.Point(532, 12);
            this.PreviewPicture.Name = "PreviewPicture";
            this.PreviewPicture.Size = new System.Drawing.Size(240, 240);
            this.PreviewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PreviewPicture.TabIndex = 0;
            this.PreviewPicture.TabStop = false;
            // 
            // FileListBox
            // 
            this.FileListBox.ContextMenuStrip = this.FilePreviewContextMenu;
            this.FileListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 16;
            this.FileListBox.Location = new System.Drawing.Point(12, 12);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(514, 244);
            this.FileListBox.TabIndex = 1;
            this.FileListBox.SelectedIndexChanged += new System.EventHandler(this.FileListBox_SelectedIndexChanged);
            this.FileListBox.DoubleClick += new System.EventHandler(this.FileListBox_DoubleClick);
            this.FileListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FileListBox_KeyUp);
            // 
            // FilePreviewContextMenu
            // 
            this.FilePreviewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilePreviewOpenMenuItem,
            this.FilePreviewShowInFolderMenuItem,
            this.FilePreviewMoveToTrashMenuItem,
            this.FilePreviewDeleteMenuItem});
            this.FilePreviewContextMenu.Name = "FilePreviewContextMenu";
            this.FilePreviewContextMenu.Size = new System.Drawing.Size(193, 114);
            this.FilePreviewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.FilePreviewContextMenu_Opening);
            // 
            // FilePreviewOpenMenuItem
            // 
            this.FilePreviewOpenMenuItem.Name = "FilePreviewOpenMenuItem";
            this.FilePreviewOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FilePreviewOpenMenuItem.Size = new System.Drawing.Size(192, 22);
            this.FilePreviewOpenMenuItem.Text = "&Open";
            this.FilePreviewOpenMenuItem.Click += new System.EventHandler(this.FilePreviewOpenMenuItem_Click);
            // 
            // FilePreviewShowInFolderMenuItem
            // 
            this.FilePreviewShowInFolderMenuItem.Name = "FilePreviewShowInFolderMenuItem";
            this.FilePreviewShowInFolderMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FilePreviewShowInFolderMenuItem.Size = new System.Drawing.Size(192, 22);
            this.FilePreviewShowInFolderMenuItem.Text = "&Show in Folder";
            this.FilePreviewShowInFolderMenuItem.Click += new System.EventHandler(this.FilePreviewShowInFolderMenuItem_Click);
            // 
            // FilePreviewMoveToTrashMenuItem
            // 
            this.FilePreviewMoveToTrashMenuItem.Name = "FilePreviewMoveToTrashMenuItem";
            this.FilePreviewMoveToTrashMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.FilePreviewMoveToTrashMenuItem.Size = new System.Drawing.Size(192, 22);
            this.FilePreviewMoveToTrashMenuItem.Text = "Move to &Trash";
            this.FilePreviewMoveToTrashMenuItem.Click += new System.EventHandler(this.FilePreviewMoveToTrashMenuItem_Click);
            // 
            // FilePreviewDeleteMenuItem
            // 
            this.FilePreviewDeleteMenuItem.Name = "FilePreviewDeleteMenuItem";
            this.FilePreviewDeleteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.FilePreviewDeleteMenuItem.Size = new System.Drawing.Size(192, 22);
            this.FilePreviewDeleteMenuItem.Text = "D&elete";
            this.FilePreviewDeleteMenuItem.Click += new System.EventHandler(this.FilePreviewDeleteMenuItem_Click);
            // 
            // DuplicatedFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 263);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.PreviewPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DuplicatedFileViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DuplicatedFileViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuplicatedFileViewer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DuplicatedFileViewer_FormClosed);
            this.Load += new System.EventHandler(this.DuplicatedFileViewer_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DuplicatedFileViewer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture)).EndInit();
            this.FilePreviewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PreviewPicture;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.ContextMenuStrip FilePreviewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem FilePreviewOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilePreviewShowInFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilePreviewMoveToTrashMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilePreviewDeleteMenuItem;
    }
}