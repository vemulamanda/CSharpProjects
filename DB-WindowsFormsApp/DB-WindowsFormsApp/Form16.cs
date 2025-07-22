using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Configuration;
using System.Data.SqlClient;

namespace DB_WindowsFormsApp
{
    public partial class Form16 : Form
    {
        DataSet ds;
        SqlDataAdapter da;

        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            //string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            da = new SqlDataAdapter("Employee_Select", ReadConStr.SConStr);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            da.SelectCommand.Parameters.Clear();

            if (comboBox1.SelectedIndex == 1)
            {                 
                da.SelectCommand.Parameters.AddWithValue("@Status", true);
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                da.SelectCommand.Parameters.AddWithValue("@Status", false);
            }
            ds = new DataSet();
            da.Fill(ds, "Employee");
            //The below property(Autogeneratecolumns) is set to true by default
            //and will generate columns automatically. But the columns set by this
            //property will not be arranged nicely. So it will have to be set to false 
            //So that we will be creating columns manually by ourselves. 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            GenerateColumns();
        }

        public void GenerateColumns()
        {
            dataGridView1.Columns.Clear();

            //To create a column in datagridview we have to instantiate a class called
            //datagridviewtextbox column
            DataGridViewTextBoxColumn EnoCol = new DataGridViewTextBoxColumn();
            //The below Headertext property is to set the column name of our choice.
            EnoCol.HeaderText = "Emp-ID";
            //Below property is original name of the column in the database.
            //After setting this property this will be bound to "EnoCol" above.
            EnoCol.DataPropertyName = "Eno";
            //Below property will set the width of the column
            EnoCol.Width = 70;
            //below line of code will align the header cell to center of the column.
            EnoCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Below code will align all the values in columns under header to center.
            EnoCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //Below code will add the columns with all the properties mentioned above to datagridview.
            dataGridView1.Columns.Add(EnoCol);

            DataGridViewTextBoxColumn EnameCol = new DataGridViewTextBoxColumn();
            EnameCol.HeaderText = "Emp-Name";
            EnameCol.DataPropertyName = "Ename";
            EnameCol.Width = 100;
            EnameCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //We dont need below code here, becoz strings are always left aligned.
            //EnameCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(EnameCol);

            DataGridViewTextBoxColumn jobCol = new DataGridViewTextBoxColumn();
            jobCol.HeaderText = "Job";
            jobCol.DataPropertyName = "Job";
            jobCol.Width = 170;
            jobCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //We dont need below code here, becoz strings are always left aligned.
            //EnameCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(jobCol);

            DataGridViewTextBoxColumn SalaryCol = new DataGridViewTextBoxColumn();
            SalaryCol.HeaderText = "Salary";
            SalaryCol.DataPropertyName = "Salary";
            SalaryCol.Width = 100;
            SalaryCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            SalaryCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(SalaryCol);

            DataGridViewCheckBoxColumn StatusCol = new DataGridViewCheckBoxColumn();
            StatusCol.HeaderText = "Status";
            StatusCol.DataPropertyName = "Status";
            StatusCol.Width = 70;
            StatusCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StatusCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(StatusCol);

            DataGridViewImageColumn ImageCol = new DataGridViewImageColumn();
            ImageCol.HeaderText = "Photo";
            ImageCol.DataPropertyName = "Photo";
            ImageCol.Width = 200;
            ImageCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //ImageCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ImageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Columns.Add(ImageCol);

            for(int i=0; i < ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 200;
            }           
        }
    }
}
