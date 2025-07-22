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
using System.Configuration;

namespace DB_WindowsFormsApp
{
    public partial class Form9 : Form
    {
        DataSet ds;
        //SqlConnection con;
        SqlDataAdapter da;
        bool Flag = false;

        public Form9()
        {
            InitializeComponent();
        }

        //The below code loads 2 tables from one data source and uses data view to display the data 
        //and then performs filtering and sort operations on tables.

        private void Form9_Load(object sender, EventArgs e)
        {
            //The below code is to load only one table in to gridview becoz each time we call fill method,
            //the previously loaded table in the dataset will be overridden.

            string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            da = new SqlDataAdapter("Select * from Employee", sqlcon);
            ds = new DataSet();
            da.Fill(ds, "Employee");
            da.SelectCommand.CommandText = "Select * from Dept";
            da.Fill(ds, "Dept");
            
            //The below code is to load one column from database in to combobox

            comboBox1.DataSource = ds.Tables["Employee"];
            comboBox1.Text = "-Select Eno-";
            comboBox1.DisplayMember = "Eno"; //Display memeber will display the Eno column in to combobox
            comboBox1.ValueMember = "Ename";//value member will get the value behind the selected value in the combobox
                                            //This is used like a tag and is helpful for developer for the searching purpose.
                                            //This is used in combination with Rowfilter method below.
                                            //From this example: the below row filter searches using Eno
                                            //and then using that Eno it sees the value member and knows what to search
                                            //with in another table. to perform this search the 2 tables must be joined 
                                            //using join method in sql database first, as this example uses join in the backend to search the tables.


            //MessageBox.Show("Tables Count: " + ds.Tables.Count);
            dataGridView1.DataSource = ds.Tables["Employee"];

            Flag = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Below code gives a default view(i.e like table in database) and also can be filtered using Rowfilter method.

            //MessageBox.Show(comboBox1.Text);
            //MessageBox.Show(comboBox1.SelectedValue.ToString());

            if (Flag)
            {
                DataView dv = ds.Tables["Employee"].DefaultView;
                //Default view is to get the default view of table. this is applied on data view.
                dv.RowFilter = $"Eno={comboBox1.SelectedValue}";
                //The above rowfilter method is applied on dataview to perform filtering on the tables.
                dv.Sort = "Salary desc";
                //The above sort method is used to sort the column in table in ascending/descending order which appeared on the data view.
            }
        }
    }
}
