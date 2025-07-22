using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Configuration;

namespace DB_WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=SQL-DSN");
            con.Open();
            MessageBox.Show("Connection state: " + con.State);
            con.Close();
            MessageBox.Show("Connection state: " + con.State);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sql authentication

            /*OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=SqlOledb;Data Source=localhost\\SQLEXPRESS;Database=Master;User Id=sudheer.kumarX@programmed.com.au;Password=Sudh@8143";
            con.Open();
            MessageBox.Show("Connection state: " + con.State);  
            con.Close();
            MessageBox.Show("Connection state: " + con.State);*/

            //windows authentication
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=SqlOledb;Data Source=localhost\\SQLEXPRESS;Database=Master;Integrated Security=SSPI";
            con.Open();
            MessageBox.Show("Connection state: " + con.State);
            con.Close();
            MessageBox.Show("Connection state: " + con.State);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //windows authentication
            SqlConnection wcon = new SqlConnection();
            wcon.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Database=Master;Integrated Security=SSPI";
            wcon.Open();
            MessageBox.Show("Connection state: " + wcon.State);
            wcon.Close();
            MessageBox.Show("Connection state: " + wcon.State);

            //Sql authentication

            /*SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Database=Master;User Id=sudheer.kumarX@programmed.com.au;Password=Sudh@8143";
            scon.Open();
            MessageBox.Show("Connection state: " + scon.State);  
            scon.Close();
            MessageBox.Show("Connection state: " + scon.State);*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Ace.Oledb.12.0;Data Source=C:\\Users\\Sudheer.Kumar\\OneDrive - Programmed\\Documents\\Personal-Docs\\PET-Project.xlsx;Extended Properties=Excel 12.0";
            con.Open();
            MessageBox.Show("Connection state: " + con.State);
            con.Close();
            MessageBox.Show("Connection state: " + con.State);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {   //ODBC connection to oracle db
            //There is no oracle installed locally in this pc. this connection is just
            //for testing purpose how we can connect to oracle db.
            OdbcConnection con = new OdbcConnection("DSN=ORACLE-DSN");
            con.Open();
            MessageBox.Show("Connection state: " + con.State);
            con.Close();
            MessageBox.Show("Connection state: " + con.State);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Oledb connection to oracle db
            //There is no oracle installed locally in this pc. this connection is just
            //for testing purpose how we can connect to oracle db.
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=OraOledb.Oracle;Data Source=localhost\\OracleEXPRESS;Database=Master;Integrated Security=SSPI";
            con.Open();
            MessageBox.Show("Connection state: " + con.State);
            con.Close();
            MessageBox.Show("Connection state: " + con.State);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = "Data Source=localhost\\OracleEXPRESS;Database=Master;Integrated Security=SSPI";
            con.Open();
            MessageBox.Show("Connection state: " + con.State);
            con.Close();
            MessageBox.Show("Connection state: " + con.State);
        }
    }
}
