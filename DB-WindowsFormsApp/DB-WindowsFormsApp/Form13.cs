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
    public partial class Form13 : Form
    {
        DataSet ds;
        SqlDataAdapter da;
        
        public Form13()
        {
            InitializeComponent();
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            da = new SqlDataAdapter("Employee_Select", sqlcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            ds = new DataSet();
            da.Fill(ds, "Employee");

            dataGridView1.DataSource = ds.Tables["Employee"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
