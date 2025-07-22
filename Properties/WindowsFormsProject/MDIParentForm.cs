using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class MDIParentForm : Form
    {
        public MDIParentForm()
        {
            InitializeComponent();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            //f.ShowDialog(); //This will open as a seperate dilog box outside parent box.

            f.MdiParent = this;
            f.Show();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.MdiParent = this;
            f.Show();
        }

        private void form10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.MdiParent = this;
            f.Show();
        }

        private void form11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.MdiParent = this;
            f.Show();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.ShowDialog();
            //f.MdiParent = this;
            //f.Show();
        }

        private void imageViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.MdiParent = this;
            f.Show();
        }
    }
}
