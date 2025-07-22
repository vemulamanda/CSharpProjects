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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=localhost\\SUDSQLSERVER;Database=CSDB;User ID=Sa;Password=Sudheer@8143");
            cmd = new SqlCommand("Select Deptno, DName, Location From Dept Order By Deptno", con);
            con.Open();
            dr = cmd.ExecuteReader();

            label1.Text = dr.GetName(0) + ": ";
            label2.Text = dr.GetName(1) + ": ";
            label3.Text = dr.GetName(2) + ": ";
        }

        public void ShowData()
        {
            if (dr.Read())
            {
                textBox1.Text = dr.GetValue(0).ToString();
                textBox2.Text = dr[1].ToString();  //using indexer
                textBox3.Text = dr["Location"].ToString(); //indexer overloading
            } else
            {
                MessageBox.Show("You have reached the last colums of the table..");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            this.Close();
        }
    }
}
