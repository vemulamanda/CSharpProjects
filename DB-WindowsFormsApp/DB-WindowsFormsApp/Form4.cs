using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DB_WindowsFormsApp
{
    public partial class Form4 : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //If we are using ODBC connection to excel data source we need to use
            //odbc coonection like this: con = new OdbcConnection("DSN=ExcelDsn;ReadOnly=0");
            //Here we are especially using ReadOnly=0(which 0 is false and 1 is true) because
            //the odbc connection opens excel document as readonly, due to this insert and update statements 
            //wont work, to make them work we need to use ReadOnly=0.

            con = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source=C:\\Users\\Sudheer.Kumar\\OneDrive - Programmed\\Documents\\Personal-Docs\\Student.xls;Extended Properties=Excel 8.0");
            cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();

            Loaddata();

            label1.Text = dr.GetName(0) + ": ";
            label2.Text = dr.GetName(1) + ": ";
            label3.Text = dr.GetName(2) + ": ";
            label4.Text = dr.GetName(3) + ": ";         
        }
        private void Loaddata()
        {

            cmd.CommandText = "Select Sno,Name,Class,Fees From [Student$]";
            dr = cmd.ExecuteReader();
            ShowData();
        }
        private void ShowData()
        {
            if (dr.Read())
            {
                textBox1.Text = dr["Sno"].ToString();
                textBox2.Text = dr["Name"].ToString();
                textBox3.Text = dr["Class"].ToString();
                textBox4.Text = dr["Fees"].ToString();
            }
            else
            {
                MessageBox.Show("You are at last record of the table");
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void NxtBtn_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            dr.Close();

            cmd.CommandText = $"Insert into [Student$] Values ({textBox1.Text},'{textBox2.Text}',{textBox3.Text},{textBox4.Text})";
            if(cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record inserted into Excel data source.","Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata();
            } else
            {
                MessageBox.Show("Record failed to insert into Excel data source.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            dr.Close();

            cmd.CommandText = $"Update [Student$] Set Name='{textBox2.Text}',Class={textBox3.Text},Fees={textBox4.Text} Where Sno={textBox1.Text}";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record updated into Excel data source.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loaddata();
            }
            else
            {
                MessageBox.Show("Record failed to update into Excel data source.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
