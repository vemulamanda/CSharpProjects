using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVCLinqToSQL.Models
{
	public class StudentDAL
	{
		//Below code creates a default constructor and takes the connection string,
		//But this default constructor is removed in recent times, so we can use directly.
		//Old style code
		/*
		public MVCDBDataContext dc;

		public StudentDAL()
		{
			string ConStr = ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString;
			dc = new MVCDBDataContext(ConStr);
		} */

		//new style code

		MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);

		public List<Student> GetStudents(bool? Status)
		{
			List<Student> Students;

			if(Status == null)
			{
				Students = dc.Students.ToList();
			}
			else
			{
				Students = (from s in dc.Students where s.Status == Status select s).ToList();
			}

            return Students;
        }	
		
		public Student GetStudent(int Sid, bool? Status)
		{
			Student Student;
			
			if(Status == null)
			{
				Student = (from s in dc.Students where s.Sid == Sid select s).Single();
			}
			else
			{
				Student = (from s in dc.Students where s.Sid == Sid && s.Status == Status select s).Single();
			}
			return Student;
		}

		public void InsertStudent(Student Student)
		{
			try
			{
                dc.Students.InsertOnSubmit(Student);
                dc.SubmitChanges();
            }
			catch(Exception ex)
			{
				throw ex;
			}
			
		}

        public void UpdateStudent(Student newStudent)
        {
            try
            {
				Student oldStudent = dc.Students.Single(S => S.Sid == newStudent.Sid);
                //dc.Students.Single(S => S.Sid == newStudent.Sid)  : This part will execute a 
				//query on database and get the specific record using Sid, it mean it gets old details of user using Sid..
                oldStudent.Name = newStudent.Name;
				oldStudent.Class = newStudent.Class;
				oldStudent.Fees = newStudent.Fees;
				oldStudent.Photo = newStudent.Photo;

				dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteStudent(int Sid)
        {
            try
            {
                Student oldStudent = dc.Students.Single(S => S.Sid == Sid);
				//dc.Students.Single(S => S.Sid == Sid)  : This part will execute a 
				//query on database and get the specific record using Sid..

				//Below code will permanantly delete the record.
				//dc.Students.DeleteOnSubmit(oldStudent);

				//Below code insteda of delete the record permanantly it will change the status to false.
				oldStudent.Status = false;

                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}