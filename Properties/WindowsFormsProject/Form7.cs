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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox2.Items.AddRange(new string[] {"Jan", "Feb", "Mar"});
                    break;

                case 1:
                    comboBox2.Items.AddRange(new string[] { "Apr", "May", "Jun" });
                    break;

                case 2:
                    comboBox2.Items.AddRange(new string[] { "Jul", "Aug", "Sep" });
                    break;

                case 3:
                    comboBox2.Items.AddRange(new string[] { "Oct", "Nov", "Dec" });
                    break;
            }
        }
    }
}
