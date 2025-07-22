using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.BackColor;
            DialogResult dr = colorDialog1.ShowDialog();
            //MessageBox.Show("Selected color is: " + colorDialog1.Color);

            if (dr == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = button2.Font; // This can be done in UI also.
            DialogResult dr = fontDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                button2.Font = fontDialog1.Font;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All Files|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string imgpath = openFileDialog1.FileName; //Filename retrieves path of file.
                pictureBox1.ImageLocation = imgpath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "*.jpg";
            saveFileDialog1.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All Files|*.*";
            DialogResult dr = saveFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //MessageBox.Show("saved location: " + saveFileDialog1.FileName);
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("HI Sudheer. Will greet you again in 3 seconds.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //MessageBox.Show("selected path: " + folderBrowserDialog1.SelectedPath);
                listBox1.Tag = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.png");
                listBox1.Items.Clear();
                //listBox1.Items.AddRange(files);
                foreach (var file in files)
                {
                    int LastSlashPos = file.LastIndexOf("\\");
                    string filename = file.Substring(LastSlashPos + 1);
                    listBox1.Items.Add(filename);
                }
                button8.Enabled = false;

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Final Selected path " + listBox1.Tag);
            //MessageBox.Show("Final Selected file name " + listBox1.SelectedItem);
            pictureBox1.ImageLocation = listBox1.Tag + "\\" + listBox1.SelectedItem;
            


            if (listBox1.SelectedIndex == 0)
            {
                button8.Enabled = false;
            } else
            {
                button8.Enabled = true;
            }

            if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                button9.Enabled = false;
            }
            else
            {
                button9.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        { 
             listBox1.SelectedIndex -= 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex += 1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
            {
                //timer2.Stop();
                listBox1.SelectedIndex = 0;
                //button11.PerformClick();
            }
            else
            {
                listBox1.SelectedIndex += 1;
            }
        }

        //int oldPanelWidth;
        object[] OldValues = new object[3];
        private void button10_Click(object sender, EventArgs e)
        {
            OldValues[0] = panel2.Width;
            OldValues[1] = this.FormBorderStyle;
            OldValues[2] = this.WindowState;

            //oldPanelWidth = panel2.Width;
            panel2.Width = 0;
            button11.Visible = true;
            timer2.Start(); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            button11.Visible = false;
            //panel2.Width = oldPanelWidth;
            this.WindowState = (FormWindowState)OldValues[2];
            this.FormBorderStyle = (FormBorderStyle)OldValues[1];
            panel2.Width = (int)OldValues[0];
        }
    }
}
