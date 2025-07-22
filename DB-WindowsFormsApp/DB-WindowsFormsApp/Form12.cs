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
    public partial class Form12 : Form
    {
        DataSet ds;

        SqlConnection con;
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        DataRelation dr;

        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString);
            da1 = new SqlDataAdapter("Select * from Emp", con);
            da2 = new SqlDataAdapter("select * from Dept", con);
            
            ds = new DataSet();
            da1.Fill(ds, "Emp");
            da2.Fill(ds, "Dept");

            //For the below relations to work there should be primary and foriegn key relationship
            //between tables mentioned in below code. This relations are used mainly to validate the 
            //user on the front end itself without sending to backend database server. 
            dr = new DataRelation("parentchild", ds.Tables["Dept"].Columns["Deptno"], ds.Tables["Emp"].Columns["Deptno"]);
            ds.Relations.Add(dr); //adding created realtion to dataset for validations.
            //ds.Tables["Emp"].Columns["Deptno"].DefaultValue = 40; //Toset default value to child columns if parent is deleted or updated.
            dr.ChildKeyConstraint.DeleteRule = Rule.None;
            //There are 4 rules here. 1. none(doesnt allow delete when rule is set(see above line of code)), 2. cascade(deletes child records when this is set.)(This is default when working in dataset and in database none is default rule.)
            //3. setnull(when parent record is deleted, makes child records as null when 'setnull' is set), 4. setdefault.(when parent record is deleted the child records are set to default value(see line 44)).
            dr.ChildKeyConstraint.UpdateRule = Rule.Cascade;

            dataGridView1.DataSource = ds.Tables["Emp"];
            dataGridView2.DataSource = ds.Tables["Dept"];
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        { 
            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            SqlCommandBuilder cb2 = new SqlCommandBuilder(da2);

            da2.Update(ds, "Dept");
            da1.Update(ds, "Emp");
        }
    }
}
