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
    public partial class Form5 : Form
    {
        DataSet ds;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
          /*  //First way of using data adapter class, Here we are just using select command method to pass cmd.
            con = new SqlConnection("Data Source=localhost\\SUDSQLSERVER;Database=CSDB;User Id=sa;Password=Sudheer@8143");
            cmd = new SqlCommand("Select Eno, Ename, Job, Salary, Status From Employee Where Status=1 Order By Eno", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            MessageBox.Show("Connection state before fill: " + con.State);
            MessageBox.Show("Table count before fill: " + ds.Tables.Count);
            da.Fill(ds, "Employee");
            MessageBox.Show("Connection state after fill: " + con.State);
            MessageBox.Show("Table count after fill: " + ds.Tables.Count);

            //Second way of using data adapter class. Here we are directly passing cmd to sql adapter class
            con = new SqlConnection("Data Source=localhost\\SUDSQLSERVER;Database=CSDB;User Id=sa;Password=Sudheer@8143");
            cmd = new SqlCommand("Select Eno, Ename, Job, Salary, Status From Employee Where Status=1 Order By Eno", con);
            da = new SqlDataAdapter(cmd);

            ds = new DataSet();
            MessageBox.Show("Connection state before fill: " + con.State);
            MessageBox.Show("Table count before fill: " + ds.Tables.Count);
            da.Fill(ds, "Employee");
            MessageBox.Show("Connection state after fill: " + con.State);
            MessageBox.Show("Table count after fill: " + ds.Tables.Count);
          */

            //Third way of using data adapter class. Here we can pass command text and connection directky to sql adapter class.
            con = new SqlConnection("Data Source=localhost\\SUDSQLSERVER;Database=CSDB;User Id=sa;Password=Sudheer@8143");
            da = new SqlDataAdapter("Select Eno, Ename, Job, Salary, Status From Employee Where Status=1 Order By Eno", con);
            
            ds = new DataSet();
            MessageBox.Show("Connection state before fill: " + con.State);
            MessageBox.Show("Table count before fill: " + ds.Tables.Count);
            da.Fill(ds, "Employee");
            MessageBox.Show("Connection state after fill: " + con.State);
            MessageBox.Show("Table count after fill: " + ds.Tables.Count);
        }
    }
}
