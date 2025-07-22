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
    public partial class Form8 : Form
    {
        DataSet ds;
        SqlDataAdapter da;

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string SConStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            da = new SqlDataAdapter("Select Eno, EName, Job, Salary, Status from Employee Order By Eno", SConStr);
            ds = new DataSet();
            da.Fill(ds, "Employee");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ForeColor = Color.Brown;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Update(ds, "Employee");
            MessageBox.Show("Data upadted in database server.");
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
