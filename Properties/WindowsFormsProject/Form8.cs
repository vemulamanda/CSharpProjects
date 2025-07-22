using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsProject
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox2.Items.AddRange(new string[] { "Andhra pradesh", "Kerala", "Tamil Nadu" });
                    break;

                case 1:
                    comboBox2.Items.AddRange(new string[] { "Victoria", "New south wales", "western Australia" });
                    break;

                case 2:
                    comboBox2.Items.AddRange(new string[] { "Alaska", "Arizona", "Arkansas" });
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox3.Items.Clear();
            
            string selectedState = comboBox2.SelectedItem.ToString();

                switch (selectedState)
                {
                case "Andhra pradesh":
                    comboBox3.Items.AddRange(new string[] { "Eluru", "Nellore", "Vijayawada" });
                    break;

                case "Kerala":
                    comboBox3.Items.AddRange(new string[] { "Kottayam", "Allapi", "Koonoor" });
                    break;

                case "Tamil Nadu":
                    comboBox3.Items.AddRange(new string[] { "chennai", "coimbatore", "Mysore" });
                    break;

                case "Victoria":
                    comboBox3.Items.AddRange(new string[] { "Melbourne", "geelong", "Ballarat" });
                    break;

                case "New south wales":
                    comboBox3.Items.AddRange(new string[] { "Sydney", "New castle", "Harris park" });
                    break;

                case "western Australia":
                    comboBox3.Items.AddRange(new string[] { "Perth", "Burbery", "Albany" });
                    break;
           
                case "Alaska":
                    comboBox3.Items.AddRange(new string[] { "Juneau", "Fairbanks", "Sitka" });
                    break;

                case "Arizona":
                    comboBox3.Items.AddRange(new string[] { "Pheonix", "Tucson", "Scotsdale" });
                    break;

                case "Arkansas":
                    comboBox3.Items.AddRange(new string[] { "Littlerock", "hotsprings", "Arkansas City" });
                    break;
            }
        }
    }
}