namespace DuplicatedFileFinder
{
    partial class SplashForm
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
            this.splashWorker = new System.ComponentModel.BackgroundWorker();
            this.splashProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // splashWorker
            // 
            this.splashWorker.WorkerReportsProgress = true;
            this.splashWorker.WorkerSupportsCancellation = true;
            this.splashWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.splashWorker_DoWork);
            this.splashWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.splashWorker_ProgressChanged);
            this.splashWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.splashWorker_RunWorkerCompleted);
            // 
            // splashProgressBar
            // 
            this.splashProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.splashProgressBar.ForeColor = System.Drawing.Color.Silver;
            this.splashProgressBar.Location = new System.Drawing.Point(2, 375);
            this.splashProgressBar.Name = "splashProgressBar";
            this.splashProgressBar.Size = new System.Drawing.Size(595, 23);
            this.splashProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.splashProgressBar.TabIndex = 0;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.ControlBox = false;
            this.Controls.Add(this.splashProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SplashForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker splashWorker;
        private System.Windows.Forms.ProgressBar splashProgressBar;
    }
}

