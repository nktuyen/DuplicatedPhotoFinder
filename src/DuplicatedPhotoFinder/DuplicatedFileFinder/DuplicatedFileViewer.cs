using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DuplicatedFileFinder
{
    public partial class DuplicatedFileViewer : Form
    {
        public List<string> Files { get; set; }
        private int OriginalCOunt { get; set; } = 0;
        public DuplicatedFileViewer(List<string> files)
        {
            InitializeComponent();
            this.Files = files;
            this.OriginalCOunt = this.Files.Count;
        }

        private void DuplicatedFileViewer_Load(object sender, EventArgs e)
        {
            FileListBox.Items.Clear();
            PreviewPicture.Image = null;
            if(this.Files.Count>0)
                foreach(string path in this.Files)
                {
                    FileListBox.Items.Add(path);
                }
        }

        private void FileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var stream = new FileStream (FileListBox.SelectedItem as string, FileMode.Open))
                {
                    PreviewPicture.Image = Image.FromStream(stream);
                    stream.Close();
                }
            }
            catch (Exception ex){
                Debug.Print(ex.Message);
            }
        }

        private void DuplicatedFileViewer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void FileListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure to delete selected file?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                try
                {
                    File.Delete(FileListBox.SelectedItem as string);
                    string path = FileListBox.SelectedItem as string;
                    this.Files.Remove(path);
                    FileListBox.Items.RemoveAt(FileListBox.SelectedIndex);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void FileListBox_DoubleClick(object sender, EventArgs e)
        {
            if (FileListBox.SelectedIndex == -1)
                return;
            string file = FileListBox.SelectedItem as string;
            ProcessStartInfo psi = new ProcessStartInfo(file);
            psi.UseShellExecute = true;
            try
            {
                Process.Start(psi);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void DuplicatedFileViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.OriginalCOunt != this.Files.Count)
                this.DialogResult = DialogResult.OK;
        }

        private void DuplicatedFileViewer_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
