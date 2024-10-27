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
            this.PreviewPicture = new System.Windows.Forms.PictureBox();
            this.FileListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPicture)).BeginInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PreviewPicture;
        private System.Windows.Forms.ListBox FileListBox;
    }
}