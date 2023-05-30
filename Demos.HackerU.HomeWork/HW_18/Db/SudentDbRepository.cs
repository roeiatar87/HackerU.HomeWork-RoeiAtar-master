using Demos.HackerU.HomeWork.Inhheritance;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Nest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_18.Db
{
    public class SudentDbRepository : ISudentRepository
    {
        readonly string connectionString;

        public SudentDbRepository()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HW18_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public SudentDbRepository(string DBconnectionString)
        {
            connectionString = DBconnectionString;
        }
        public bool AddNewStudent(StudentModel student)
        {
            int rowAffected = 0;
            string queryInsert = "INSERT INTO Student (idNum, FirstName,LastName,Email,CourseName,Tel,City,Address,StartCourseDate,GradeAvg) " +
                                  "VALUES (@idnum, @firstName,@lastname,@email,@coursename,@tel,@city,@address,@startcoursedate,@gradeavg)";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(queryInsert, con);
                //Here we will insert the correct values into the placeholders via the commands
                //parameters

                cmd.Parameters.AddWithValue("@idnum", student.IdNum);
                cmd.Parameters.AddWithValue("@firstName", student.FirstName);
                cmd.Parameters.AddWithValue("@lastname", student.LastName);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@coursename", student.CourseName);
                cmd.Parameters.AddWithValue("@tel", student.Tel);
                cmd.Parameters.AddWithValue("@city", student.City);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@startcoursedate", student.StartCourseDate);
                cmd.Parameters.AddWithValue("@gradeavg", student.GradeAvg);


                //INSERT/DELETE/UPDATE use ExecuteNonQuery
                rowAffected = cmd.ExecuteNonQuery();

            }
            return (rowAffected > 0);
        }

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> list = new List<StudentModel>();
            //1) Create Connection using connectionstring
            var con = new SqlConnection(connectionString);
            try
            {
                //2) CREATE SQL COMMAND  
                string query = "SELECT * FROM Student";
                SqlCommand cmd = new SqlCommand(query, con);

                //3) Open Connection
                con.Open();

                //4) EXecute Command And Get Reader
                SqlDataReader dbReader = cmd.ExecuteReader();

                //5) Use Reader to read each row in a loop
                //true while row is not EOF of ROWS Data
                while (dbReader.Read()) //Single row for each iteration
                {
                    //Convert From SQL TYPE TO C# TYPE with Column Index
                    int id = dbReader.GetInt32(0);
                    // int id = dbReader.GetFieldValue<int>("Id");
                    int idNum = dbReader.GetInt32(1);
                    string firstName = dbReader.GetString(2);
                    string lastName = dbReader.GetString(3);
                    string email = dbReader.GetString(4);
                    string courseName = dbReader.GetString(5);
                    string tel = dbReader.GetString(6);
                    string city = dbReader.GetString(7);
                    string address = dbReader.GetString(8);
                    DateTime startCourseDate = dbReader.GetDateTime(9);
                    float gradeAvg = ((float)dbReader.GetDouble(10));

                    StudentModel student = new StudentModel()
                    {
                        Id = id,
                        IdNum = idNum,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        CourseName = courseName,
                        Tel = tel,
                        City = city,
                        Address = address,
                        StartCourseDate = startCourseDate,
                        GradeAvg = gradeAvg,
                    };


                    list.Add(student);
                }

                dbReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            return list;
        }

        public List<StudentModel> GetAllStudentsByCourse(string coursename)
        {
            List<StudentModel> list = new List<StudentModel>();
            //1) Create Connection using connectionstring
            var con = new SqlConnection(connectionString);
            try
            {
                //2) CREATE SQL COMMAND  
                string query = "SELECT * FROM Student WHERE CourseName=@courseName";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@courseName", coursename);

                //3) Open Connection
                con.Open();

                //4) EXecute Command And Get Reader
                SqlDataReader dbReader = cmd.ExecuteReader();

                //5) Use Reader to read each row in a loop
                //true while row is not EOF of ROWS Data
                while (dbReader.Read()) //Single row for each iteration
                {
                    //Convert From SQL TYPE TO C# TYPE with Column Index
                    int id = dbReader.GetInt32(0);
                    // int id = dbReader.GetFieldValue<int>("Id");
                    int idNum = dbReader.GetInt32(1);
                    string firstName = dbReader.GetString(2);
                    string lastName = dbReader.GetString(3);
                    string email = dbReader.GetString(4);
                    string courseName = dbReader.GetString(5);
                    string tel = dbReader.GetString(6);
                    string city = dbReader.GetString(7);
                    string address = dbReader.GetString(8);
                    DateTime startCourseDate = dbReader.GetDateTime(9);
                    float gradeAvg = ((float)dbReader.GetDouble(10));

                    StudentModel student = new StudentModel()
                    {
                        Id = id,
                        IdNum = idNum,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        CourseName = courseName,
                        Tel = tel,
                        City = city,
                        Address = address,
                        StartCourseDate = startCourseDate,
                        GradeAvg = gradeAvg,
                    };


                    list.Add(student);
                }

                dbReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            return list;
        }

        public StudentModel GetStudentByID(int studentID)
        {
            StudentModel student = null;
            //1) Create Connection using connectionstring
            var con = new SqlConnection(connectionString);
            try
            {
                //2) CREATE SQL COMMAND  
                string query = "SELECT * FROM Student WHERE IdNum=@idNum";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idNum", studentID);

                //3) Open Connection
                con.Open();

                //4) EXecute Command And Get Reader
                SqlDataReader dbReader = cmd.ExecuteReader();

                //5) Use Reader to read each row in a loop
                //true while row is not EOF of ROWS Data
                while (dbReader.Read()) //Single row for each iteration
                {
                    //Convert From SQL TYPE TO C# TYPE with Column Index
                    int id = dbReader.GetInt32(0);
                    // int id = dbReader.GetFieldValue<int>("Id");
                    int idNum = dbReader.GetInt32(1);
                    string firstName = dbReader.GetString(2);
                    string lastName = dbReader.GetString(3);
                    string email = dbReader.GetString(4);
                    string courseName = dbReader.GetString(5);
                    string tel = dbReader.GetString(6);
                    string city = dbReader.GetString(7);
                    string address = dbReader.GetString(8);
                    DateTime startCourseDate = dbReader.GetDateTime(9);
                    float gradeAvg = ((float)dbReader.GetDouble(10));

                    student = new StudentModel()
                    {
                        Id = id,
                        IdNum = idNum,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        CourseName = courseName,
                        Tel = tel,
                        City = city,
                        Address = address,
                        StartCourseDate = startCourseDate,
                        GradeAvg = gradeAvg,
                    };



                }

                dbReader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            return student;
        }


        public bool DeleteStudentByID(int idnum)
        {
            int rowAffected = 0;
            string queryDelete = "DELETE FROM Student WHERE idNum=@idParam";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(queryDelete, con);
                //Here we will insert the correct values into the placeholders via the commands
                //parameters

                cmd.Parameters.AddWithValue("@idParam", idnum);

                //INSERT/DELETE/UPDATE use ExecuteNonQuery
                rowAffected = cmd.ExecuteNonQuery();

            }
            return (rowAffected > 0);
        }

        public void SaveLastStudentToFile(StudentModel studentModel)
        {

        }
        public void UpdateStudentByID(int idnum, StudentModel student)
        {

            int rowAffected = 0;
            string queryInsert = "UPDATE Student SET " +
                         "IdNum=@idNum, " +
                         "FirstName=@firstName, " +
                         "LastName=@lastName, " +
                         "Email=@email, " +
                         "CourseName=@courseName, " +
                         "Tel=@tel, " +
                         "City=@city, " +
                         "Address=@address, " +
                         "StartCourseDate=@startcoursedate, " +
                         "GradeAvg=@gradeavg " +
                         "WHERE IdNum=@idNum";


            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(queryInsert, con);
                //cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idnum", idnum);
                cmd.Parameters.AddWithValue("@firstName", student.FirstName);
                cmd.Parameters.AddWithValue("@lastname", student.LastName);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@coursename", student.CourseName);
                cmd.Parameters.AddWithValue("@tel", student.Tel);
                cmd.Parameters.AddWithValue("@city", student.City);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@startcoursedate", student.StartCourseDate);
                cmd.Parameters.AddWithValue("@gradeavg", student.GradeAvg);


                rowAffected = cmd.ExecuteNonQuery();

            }

        }

        //Exit(press 8)


    }
}
