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
using Microsoft.VisualBasic.FileIO;


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
            string file = FileListBox.SelectedItem as string;
            string ext = System.IO.Path.GetExtension(file).ToUpper();
            PreviewPicture.Image = null;
            if (ext == ".JPG" || ext == ".JPEG" || ext == ".PNG" || ext == ".BMP" || ext == ".GIF" || ext == ".TIFF")
            {
                try
                {
                    using (var stream = new FileStream(file, FileMode.Open))
                    {
                        PreviewPicture.Image = Image.FromStream(stream);
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }
        }

        private void DuplicatedFileViewer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void FileListBox_KeyUp(object sender, KeyEventArgs e)
        {
           
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

        private void FilePreviewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            FilePreviewContextMenu.Enabled = FileListBox.SelectedIndex != -1;
        }

        private void FilePreviewOpenMenuItem_Click(object sender, EventArgs e)
        {
            string file = FileListBox.SelectedItem as string;
            ProcessStartInfo psi = new ProcessStartInfo(file);
            psi.UseShellExecute = true;
            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void FilePreviewShowInFolderMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FilePreviewMoveToTrashMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileSystem.DeleteFile(FileListBox.SelectedItem as string, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                string path = FileListBox.SelectedItem as string;
                this.Files.Remove(path);
                FileListBox.Items.RemoveAt(FileListBox.SelectedIndex);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void FilePreviewDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to permanently delete selected file?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                File.Delete(FileListBox.SelectedItem as string);
                string path = FileListBox.SelectedItem as string;
                this.Files.Remove(path);
                FileListBox.Items.RemoveAt(FileListBox.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
