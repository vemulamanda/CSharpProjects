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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add("Andhra pradesh");
            listBox1.Items.Add("Telangana");
            listBox1.Items.Add("Kerala");
            listBox1.Items.Add("Karnataka");
            listBox1.Items.Add("Tamil Nadu");
            listBox1.Items.Add("Maharastra");
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] cities = { "Delhi", "mumbai", "Hyderabad", "Vijayawada", "cochin" };

            checkedListBox1.Items.AddRange(cities);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (comboBox1.FindStringExact(comboBox1.Text) == -1)
                {
                    comboBox1.Items.Add(comboBox1.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selected Item: " + comboBox1.Text);
            MessageBox.Show("Selected Item: " + comboBox1.SelectedItem);
            MessageBox.Show("Selected Item: " + comboBox1.Items[comboBox1.SelectedIndex]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBox1.SelectedItems)
            {
                MessageBox.Show("Selected Item: " + obj);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (object obj in checkedListBox1.CheckedItems)
            {
                str += obj + ", ";
            }

            str = str.Substring(0, str.Length - 2);
            int pos = str.LastIndexOf(",");
            if (pos != -1)
            {
                str = str.Remove(pos, 1);
                str = str.Insert(pos, " and");
            }
            MessageBox.Show("Selected Item: " + str);
        }
    }
}
