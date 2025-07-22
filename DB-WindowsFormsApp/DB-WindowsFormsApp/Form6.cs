using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.VisualBasic.Interaction;
using System.Configuration;

namespace DB_WindowsFormsApp
{
    public partial class Form6 : Form
    {
        DataSet ds;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        int RowIndex = 0;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            InsertBtn.Enabled = false;

            string SqlConnStr = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString; //To get coonection string from app.config file.
            con = new SqlConnection(SqlConnStr);
            da = new SqlDataAdapter("Select Eno, Ename, Job, Salary From Employee Order By Eno", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;  //To get row with primary key details.
            ds = new DataSet();
            //MessageBox.Show("No of tables in dataset before fill method: " + ds.Tables.Count);
            da.Fill(ds, "Employee");
            //MessageBox.Show("No of tables in dataset after fill method: " + ds.Tables.Count);
        }

        private void FirstBtn_Click(object sender, EventArgs e)
        {
            RowIndex = 0;
            ShowData();
        }

        private void ShowData()
        {
            if (ds.Tables[0].Rows[RowIndex].RowState != DataRowState.Deleted)
            {
                textBox1.Text = ds.Tables[0].Rows[RowIndex]["Eno"].ToString();
                textBox2.Text = ds.Tables[0].Rows[RowIndex]["Ename"].ToString();
                textBox3.Text = ds.Tables[0].Rows[RowIndex]["Job"].ToString();
                textBox4.Text = ds.Tables[0].Rows[RowIndex]["Salary"].ToString();
            } else
            {
                MessageBox.Show("The Data row you are currently trying to access is deleted.");
            }
        }

        private void NxtBtn_Click(object sender, EventArgs e)
        {
            if (RowIndex < ds.Tables[0].Rows.Count - 1)
            {
                RowIndex++;
                ShowData();
            } else
            {
                MessageBox.Show("You are at the last row..");
            }
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if(RowIndex > 0)
            {
                RowIndex--;
                ShowData();
            } else
            {
                MessageBox.Show("You are on the 1st row..");
            }
        }

        private void LastBtn_Click(object sender, EventArgs e)
        {
            RowIndex = ds.Tables[0].Rows.Count - 1;
            ShowData();
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            int LastRowIndex = ds.Tables[0].Rows.Count - 1;
            int EnoRow = Convert.ToInt32(ds.Tables[0].Rows[LastRowIndex]["Eno"].ToString()) + 1;
            textBox1.Text = EnoRow.ToString();

            InsertBtn.Enabled = true;
            textBox2.Focus();
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;
            ds.Tables[0].Rows.Add(dr);
            RowIndex = ds.Tables[0].Rows.Count - 1;
            InsertBtn.Enabled = false;
            MessageBox.Show("Your record is inserted into the local dataset.");
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[RowIndex]["Ename"] = textBox2.Text;
            ds.Tables[0].Rows[RowIndex]["Job"] = textBox3.Text;
            ds.Tables[0].Rows[RowIndex]["Salary"] = textBox4.Text;
            MessageBox.Show("The new values are updated in the local dataset..");
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[RowIndex].Delete();
            FirstBtn.PerformClick();
            MessageBox.Show("Row deleted from local data set.");
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "Employee");
            MessageBox.Show("Saved to database server..");
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string value = InputBox("Please enter employee ID: ");
            //MessageBox.Show(value);
            if(int.TryParse(value, out int Eno))
            {
                DataRow dr = ds.Tables[0].Rows.Find(Eno);
                RowIndex = ds.Tables[0].Rows.IndexOf(dr);
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
            } 
            else
            {
                MessageBox.Show("Please enter correct number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }

        }
    }
}
