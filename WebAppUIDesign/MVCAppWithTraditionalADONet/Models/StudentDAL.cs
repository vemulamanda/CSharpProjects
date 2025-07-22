using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace MVCAppWithTraditionalADONet.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;

        public StudentDAL()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public List<Student> Student_Select(int? Sid, bool? Status)
        {
            List<Student> students = new List<Student>();

            try
            {
                cmd.Parameters.Clear();

                cmd.CommandText = "Student_Select";

                if (Sid == null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", Status);
                }
                else if (Sid != null && Status == null)
                {
                    cmd.Parameters.AddWithValue("@Sid", Sid);
                }
                else if (Sid != null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Sid", Sid);
                    cmd.Parameters.AddWithValue("@Status", Status);
                }

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Student s = new Student
                    {
                        Sid = Convert.ToInt32(dr["Sid"]),
                        Name = dr["Name"].ToString(),
                        Class = Convert.ToInt32(dr["Class"]),
                        Fees = Convert.ToDecimal(dr["Fees"]),
                        Photo = dr["Photo"].ToString()
                    };
                    students.Add(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return students;
        }

        public int Insert_Student(Student student)
        {
            int Count = 0;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Insert";
                cmd.Parameters.AddWithValue("@Sid", student.Sid);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                if (student.Photo != null && student.Photo.Trim().Length != 0)
                {
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                }
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public int Update_Student(Student student)
        {
            int Count = 0;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Update";
                cmd.Parameters.AddWithValue("@Sid", student.Sid);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                if (student.Photo != null && student.Photo.Trim().Length != 0)
                {
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                }
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
        public int Delete_Student(int Sid)
        {
            int Count = 0;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Student_Delete";
                cmd.Parameters.AddWithValue("@Sid", Sid);
               
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }
    }
}