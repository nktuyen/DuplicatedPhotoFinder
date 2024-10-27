using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicatedFileFinder
{
    public partial class ListViewEx : ListView
    {
        public System.Windows.Forms.AutoScaleMode AutoScaleMode { get; set; }
        public ListViewEx()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
    }
}
