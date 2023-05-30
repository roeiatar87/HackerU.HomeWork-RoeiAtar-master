using Demos.HackerU.HomeWork.Inhheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_18.Ef
{
    public class SudentEfRepository : ISudentRepository
    {

        private static SudentEfRepository Instance = null;
        private SudentEfRepository()
        {

        }

        public static SudentEfRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SudentEfRepository();
            }
            return Instance;
        }

        public bool AddNewStudent(StudentModel student)
        {
            using (StudentEfContext Db = new StudentEfContext())
            {
                Db.StudentModels.Add(student);
                Db.SaveChanges();
                return true;
            }

        }

        public bool DeleteStudentByID(int idnum)
        {
            using (StudentEfContext Db = new StudentEfContext())
            {
                var studentId = Db.StudentModels.SingleOrDefault(x => x.IdNum == idnum);
                if (studentId != null)
                {
                    Db.StudentModels.Remove(studentId);
                    Db.SaveChanges();
                    return true;
                }

            }
            return false;
        }
        public List<StudentModel> GetAllStudents()
        {
            var list = new List<StudentModel>();
            using (StudentEfContext Db = new StudentEfContext())
            {

                list = Db.StudentModels.ToList();
            }

            return list;
        }
        public List<StudentModel> GetAllStudentsByCourse(string courseName)
        {
            var list = new List<StudentModel>();
            using (StudentEfContext Db = new StudentEfContext())
            {

                list = Db.StudentModels.Where(x => x.CourseName == courseName).ToList();
            }
            return list;
        }

        public StudentModel GetStudentByID(int idnum)
        {
            var student = new StudentModel();
            using (StudentEfContext Db = new StudentEfContext())
            {
                student = Db.StudentModels.SingleOrDefault(x => x.IdNum == idnum);
            }
            return student;
        }

        public void SaveLastStudentToFile(StudentModel studentModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentByID(int idnum, StudentModel studentModel)
        {
            using (StudentEfContext Db = new StudentEfContext())
            {
                var s1 = Db.StudentModels.SingleOrDefault(x => x.IdNum == idnum);
                if (s1 != null)
                {
                    s1.Address = studentModel.Address;
                    s1.City = studentModel.City;
                    s1.Email = studentModel.Email;
                    s1.CourseName = studentModel.CourseName;
                    s1.IdNum = s1.IdNum;
                    s1.LastName = studentModel.LastName;
                    s1.FirstName = studentModel.FirstName;
                    s1.GradeAvg = studentModel.GradeAvg;
                    s1.StartCourseDate = studentModel.StartCourseDate;
                    s1.Tel = studentModel.Tel;
                    Db.SaveChanges();
                }


            }
        }

    }
}
