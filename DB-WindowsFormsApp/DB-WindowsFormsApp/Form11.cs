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
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DB_WindowsFormsApp
{
    public partial class Form11 : Form
    {
        DataSet ds;

        SqlConnection con;
        SqlDataAdapter sda;
        OleDbDataAdapter Eda;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            string Excon = ConfigurationManager.ConnectionStrings["ExcelConStr"].ConnectionString;

            sda = new SqlDataAdapter("select Eno, Ename, Job, Salary, Status from Employee Order By Eno", sqlcon);
            Eda = new OleDbDataAdapter("Select * from [student$]", Excon);

            ds = new DataSet();

            sda.Fill(ds, "Employee");
            Eda.Fill(ds, "student");

            //ds.WriteXml("C:\\Users\\Sudheer.Kumar\\OneDrive - Programmed\\Documents\\Personal-Docs\\tables.xml");

            //MessageBox.Show("Tables in data set are: " + ds.Tables.Count);
            dataGridView1.DataSource = ds.Tables["Employee"];
            dataGridView2.DataSource = ds.Tables["Student"];
        }

        private void SqlSaveBtn_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(ds, "Employee");
            MessageBox.Show("Data stored into sql database");
        }

        private void ExcelSaveBtn_Click(object sender, EventArgs e)
        {
            //Excel doesnt work because it doesnt have primary key on the table. 
            OleDbCommandBuilder OCB = new OleDbCommandBuilder(Eda);
            Eda.Update(ds, "Student");
            MessageBox.Show("Data stored into Excel database");
        }
    }
}
