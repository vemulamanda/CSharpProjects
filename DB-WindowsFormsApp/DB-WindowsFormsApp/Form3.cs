using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_WindowsFormsApp
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=localhost\\SUDSQLSERVER;Database=CSDB;User ID=Sa;Password=Sudheer@8143");
            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            
            LoadData();
        }

        private void LoadData()
        {
            cmd.CommandText = "Select Eno, Ename, Job, Salary, Status From Employee Where Status=1 Order By Eno";
            dr = cmd.ExecuteReader();
            ShowData();
        }

        private void ShowData()
        {
            InsertBtn.Enabled = false;

            if(dr.Read())
            {
                textBox1.Text = dr["Eno"].ToString();
                textBox2.Text = dr["Ename"].ToString();
                textBox3.Text = dr["Job"].ToString();
                textBox4.Text = dr["Salary"].ToString();
                checkBox1.Checked = (bool)dr["Status"];
            } else
            {
                MessageBox.Show("You have reached the end of records or you have no records in the table..");
            }
        }

        private void NxtBtn_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            InsertBtn.Enabled = true;
            checkBox1.Enabled = true;

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            checkBox1.Checked = false;
            dr.Close();
            cmd.CommandText = "Select IsNull(Max(Eno), 100) + 1 From Employee";
            textBox1.Text = cmd.ExecuteScalar().ToString();
            textBox2.Focus();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            //dr.Close();
            cmd.CommandText = $"Insert Into Employee (Eno, Ename, Job, Salary, Status) Values({textBox1.Text}, '{textBox2.Text}', '{textBox3.Text}', {textBox4.Text}, {Convert.ToInt32(checkBox1.Checked)})";
            if(cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record inserted into the table.");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                checkBox1.Checked = false;
                InsertBtn.Enabled = false;
                checkBox1.Enabled = false;

                LoadData();
            } else
            {
                MessageBox.Show("Failed to insert records into the table. Please click insert to try again or try inserting new record again..");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            dr.Close();

            cmd.CommandText = $"Update Employee Set Ename='{textBox2.Text}',Job='{textBox3.Text}',Salary={textBox4.Text} Where Eno={textBox1.Text}";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record Updated in the table.");
                checkBox1.Checked = false;
                checkBox1.Enabled = false;

                LoadData();
            }
            else
            {
                MessageBox.Show("Failed to update records into the table. Please click Update to try again or try inserting new record..");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            dr.Close();

            if (MessageBox.Show("Are you sure you want to disable the record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cmd.CommandText = $"Update Employee Set Status=0 Where Eno={textBox1.Text}";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("This Record in the table is now Disabled.");
                    checkBox1.Checked = false;
                    checkBox1.Enabled = false;

                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to Disable records in the table. Please try again..");
                }
            }
        }
    }
}
