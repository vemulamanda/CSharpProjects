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
    public partial class Form4 : Form
    {
        int count;
        public Form4()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            radioButton1.Checked = true;
            //MessageBox.Show(cb.Tag.ToString());
            int Amt = int.Parse(lbltxtFees.Text);
            
            if (cb.Checked)
            {
                count += 1;
                Amt += Convert.ToInt32(cb.Tag);
            } else
            {
                count -= 1;
                Amt -= Convert.ToInt32(cb.Tag);
            }
            lbltxtFees.Text = Amt.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            RadioButton rb = (RadioButton)sender;
 
            int Amt = int.Parse(lbltxtFees.Text);
            if (rb.Checked)
            {
                Amt += Convert.ToInt32(rb.Tag) * count;
            } else
            {
                Amt -= Convert.ToInt32(rb.Tag) * count;
            }
            lbltxtFees.Text = Amt.ToString();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in panel1.Controls)
            {
                if(ctrl is CheckBox)
                {
                    CheckBox cb = (CheckBox)ctrl;
                    cb.Checked = false;
                }
            }

            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox tb = (TextBox)ctrl;
                    tb.Clear();
                }
            }
            lbltxtFees.Text = "0";
            lbltxtName.Focus();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to close the form", "Confirmation Dilog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //MessageBox.Show(dr.ToString());
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
