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
using System.IO;
using static Microsoft.VisualBasic.Interaction;

namespace DB_WindowsFormsApp
{
    public partial class Form15 : Form
    {
        SqlCommand cmd;
        SqlConnection con;

        string ImgPath = "";
        byte[] imgData = null;

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            string sqlcon = ConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString;
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

        }
        private void SelectBtn_Click(object sender, EventArgs e)
        {
            string Value = InputBox("Enter Employee no: ");
            if(int.TryParse(Value, out int Eno))
            {
                try
                {
                    cmd.CommandText = "Employee_Select";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Eno", Eno);
                    cmd.Parameters.AddWithValue("@Status", true);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        textBox1.Text = dr["Eno"].ToString();
                        textBox2.Text = dr["Ename"].ToString();
                        textBox3.Text = dr["Job"].ToString();
                        textBox4.Text = dr["Salary"].ToString();

                        if (dr["Photo"] != DBNull.Value)
                        {
                            imgData = (byte[])dr["Photo"];
                            //Below code gives permissions issues so we opt to write the 
                            //stream of bytes directly into the memory.

                            //File.WriteAllBytes("C:\\CustomerPic.jpg", imgData);
                            //pictureBox1.ImageLocation = "C:\\CustomerPic.jpg";
                            MemoryStream ms = new MemoryStream(imgData);
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            ImgPath = "";
                            imgData = null;
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Employee exists with a given number. Please enter valis Employee iD.");
                        ClearBtn.PerformClick();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }   
        }     
        private void NewBtn_Click_1(object sender, EventArgs e)
        {
            

                if (NewBtn.Text == "New")
                {
                    ClearBtn.PerformClick();
                    NewBtn.Text = "Insert";
                }
                else
                {
                    try
                    {
                    //When passing input parameters use add with value method to send data. 
                    cmd.CommandText = "Employee_Insert";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Ename", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Job", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Salary", textBox4.Text);

                    //when sending image you have to store binary of the image in to database instead of path.
                    //To get the binary of the image, you have to use "File.readallbytes" and pass image path.
                    //and then you have to pass binary image data using add with value. for this you have declared
                    //imgData as byte data type in the fields.
                    if (ImgPath.Trim().Length > 0)
                    {
                        imgData = File.ReadAllBytes(ImgPath);
                        cmd.Parameters.AddWithValue("@Photo", imgData);
                    }
                    else
                    {
                        //Here DB Type is mandatory only when imgpath is null.
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = DBNull.Value;
                        //cmd.Parameters.Add("@Photo", DBNull.Value);
                        //cmd.Parameters["@Photo"].SqlDbType = SqlDbType.VarBinary;
                    }

                    cmd.Parameters.Add("@Eno", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    textBox1.Text = cmd.Parameters["@Eno"].Value.ToString();
                    ImgPath = ""; imgData = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();

                    NewBtn.Text = "New";
                }
            }
            
            
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "Employee_Update";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Eno", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ename", textBox2.Text);
                cmd.Parameters.AddWithValue("@Job", textBox3.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox4.Text);

                if (imgData == null && ImgPath.Trim().Length == 0)
                {
                    cmd.Parameters.AddWithValue("@Photo", DBNull.Value);
                    cmd.Parameters["@Photo"].SqlDbType = SqlDbType.VarBinary;
                }
                else if(ImgPath.Trim().Length > 0)
                {
                    imgData = File.ReadAllBytes(ImgPath);
                    cmd.Parameters.AddWithValue("@Photo", imgData);
                } 
                else
                {
                    cmd.Parameters.AddWithValue("@Photo", imgData);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated new data to database..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();

                NewBtn.Text = "New";
            }

        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "Employee_Delete";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Eno", textBox1.Text);
                con.Open();
                cmd.ExecuteNonQuery();

                ClearBtn.PerformClick();

                MessageBox.Show("Record deleted in database..");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();

                NewBtn.Text = "New";
            }

        }
        private void FormCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            imgData = null;
            ImgPath = "";
            pictureBox1.Image = null;
            textBox2.Focus();
        }
        private void ImgLoadBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Jpeg Images|*.jpg|PNG Images|*.png|Bitmap Images|*.bmp|All Files|*.*";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                ImgPath = openFileDialog1.FileName;
                pictureBox1.ImageLocation = ImgPath;
            }
        }
        private void PicCloseBtn_Click(object sender, EventArgs e)
        {
            ImgPath = "";
            imgData = null;
            pictureBox1.Image = null;
        }
    }
}
