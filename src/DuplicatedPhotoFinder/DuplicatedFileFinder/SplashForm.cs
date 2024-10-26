using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicatedFileFinder
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void splashWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void splashWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (splashProgressBar.InvokeRequired) {
                splashProgressBar.Invoke(new MethodInvoker(delegate {
                    splashProgressBar.Value = e.ProgressPercentage;
                }));
            } else {
                splashProgressBar.Value = e.ProgressPercentage;
            }
        }

        private void splashWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 100; i++)
            {
                if (splashWorker.CancellationPending)
                    break;
                Thread.Sleep(1);
                splashWorker.ReportProgress(i);
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            splashWorker.RunWorkerAsync();
        }
    }
}
