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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void SaveFile()
        {
            
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.Filter = "All Files|*.*|JPEG Images|*.jpg|PNG Images|*.png";

            DialogResult dr = saveFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string filepath = saveFileDialog1.FileName;
                File.WriteAllText(filepath, richTextBox1.Text);
            }
        }

        string OpenedFileText;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           if (richTextBox1.Text == "" || richTextBox1.Text == OpenedFileText)
            {
                richTextBox1.Clear();
            } else
            {
               DialogResult dr = MessageBox.Show("Do you want save changes to untitled", "Notepad", MessageBoxButtons.YesNoCancel);

               if (dr == DialogResult.Yes)
                {
                    SaveFile(); 
                }
                else if (dr == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                wordWrapToolStripMenuItem.Checked = false;
            } else
            {
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AB = new AboutBox1();
            AB.ShowDialog();
        }

        /*private void OpenFile()
        {
            
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                OpenFilePath = openFileDialog1.FileName;
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }*/

        string OpenFilePath;
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            if (richTextBox1.Text == "" || richTextBox1.Text == OpenedFileText)
            {
                //OpenFile();
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    OpenFilePath = openFileDialog1.FileName;
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    OpenedFileText = richTextBox1.Text;
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want save changes to untitled", "Notepad", MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (dr == DialogResult.No)
                {
                    //richTextBox1.Clear();
                    //OpenFile();
                    
                    DialogResult dr1 = openFileDialog1.ShowDialog();
                    if (dr1 == DialogResult.OK)
                    {
                        OpenFilePath = openFileDialog1.FileName;
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(OpenFilePath, richTextBox1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                this.Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want save changes to untitled", "Notepad", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    SaveFile();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
