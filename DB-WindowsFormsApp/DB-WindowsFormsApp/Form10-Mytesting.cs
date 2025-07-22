using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace DB_WindowsFormsApp
{
    public partial class Form10 : Form
    {
        DataSet ds;
        string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
        //SqlConnection con;
        SqlDataAdapter da;

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Employee");
            comboBox1.Items.Add("Dept");
            comboBox1.Items.Add("Salgrade");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "Employee")
            {
                da = new SqlDataAdapter("select * from Employee", sqlcon); 
                ds = new DataSet();
                da.Fill(ds, "Employee");
                dataGridView1.DataSource = ds.Tables["Employee"];
            }

            if (comboBox1.SelectedItem == "Dept")
            {
                da = new SqlDataAdapter("select * from Dept", sqlcon);
                ds = new DataSet();
                da.Fill(ds, "Dept");
                dataGridView1.DataSource = ds.Tables["Dept"];
            }

            if (comboBox1.SelectedItem == "Salgrade")
            {
                da = new SqlDataAdapter("select * from Salgrade", sqlcon);
                ds = new DataSet();
                da.Fill(ds, "Salgrade");
                dataGridView1.DataSource = ds.Tables["Salgrade"];
            }

        }
    }
}
