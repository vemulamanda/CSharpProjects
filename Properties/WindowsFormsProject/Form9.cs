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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = "C:\\Users\\Sudheer.Kumar\\OneDrive - Programmed\\Documents\\Personal-Docs\\OIP.jfif";
            pictureBox1.Image = Image.FromFile("C:\\Users\\Sudheer.Kumar\\OneDrive - Programmed\\Documents\\Personal-Docs\\OIP.jfif");
        }
    }
}
