using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Performing load and click event on single event.");
        }

        //To keep all the controls under one event procedure(method), we have to select
        //all the controls in GUI at once and bind this method under specific event you want.
        //So for example, when you click on button first the button object is stored under the parameter
        //"object sender" and then it performs inheritance..
        //How inheritance is performed:

        /*
         child : parent

        child c = new child(); //here we can access all members of child class but not parent
        parent p = c; //here we cant access pure child class members, so we have to create child reference again
        child obj = (child)p;  OR child obj = p as child;

        example for below code:

        Button : Object
        Button button1 = new Button();
        Object sender = button1;
        Button b = (Button)sender

        so when you bind all events under one event procedure(method), when you click 
        control the control is passed to "object sender" and then it performs inheritance
        implicitly and then all properties are accessible under button instance 'b'.

         */
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.GetType().ToString());
            //MessageBox.Show(sender.GetType().Name);
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Name == "button1")
                {
                    MessageBox.Show("Button1 is clicked by user..");
                }
                else
                {
                    MessageBox.Show("Button2 is clicked by user..");
                }
            }
            else if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;
                MessageBox.Show("Textbox is clicked by user..");
            }
            else if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                //MessageBox.Show("Radio button is clicked by user..");
            }
            else
            {
                Form f = (Form)sender;
                MessageBox.Show("Form is clicked by user..");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) 
            {
                MessageBox.Show("radio button 1 is checked");
            } else
            {
                MessageBox.Show("radio button 2 is checked");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("check box-1 is checked");
            }
            if (checkBox2.Checked)
            {
                MessageBox.Show("check box-2 is checked");
            }
            if (checkBox3.Checked)
            {
                MessageBox.Show("check box-3 is checked");
            }
        }
    }
}
