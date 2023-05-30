using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_18
{
    public class ConsoleService
    {
        public static StudentModel GetStudentFromUser()
        {

            StudentModel student = new StudentModel();

            Console.WriteLine("Insert First Name :");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Insert Last Name :");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Insert Email :");
            student.Email = Console.ReadLine();
            Console.WriteLine("Insert Id Number only numbers:");
            student.IdNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert Course Name :");
            student.CourseName = Console.ReadLine();
            Console.WriteLine("Insert Phone number :");
            student.Tel = Console.ReadLine();
            Console.WriteLine("Insert City :");
            student.City = Console.ReadLine();
            Console.WriteLine("Insert Address :");
            student.Address = Console.ReadLine();
            student.StartCourseDate = DateTime.Now;
            Console.WriteLine("Insert Grade Avg ,Only numbers 1-100:");
            student.GradeAvg = float.Parse(Console.ReadLine());

            Console.WriteLine("\nYour details have been successfully received");
            Console.WriteLine(student);
            return student;
        }

        public static void PrintAllStudents(List<StudentModel> students)
        {
            foreach (StudentModel student in students)
            {
                Console.WriteLine(student);
            }
        }

        public static string GetCourseNameFromUser(List<StudentModel> list)
        {
            PrintAllCourseNames(list);
            Console.WriteLine("\nEnter Course Name from list :\n");
            string courseName = Console.ReadLine();
            return courseName;
        }

        public static void PrintAllCourseNames(List<StudentModel> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No students in the list.");
                return;
            }

            HashSet<string> courseNames = new HashSet<string>();
            foreach (StudentModel student in list)
            {
                courseNames.Add(student.CourseName);
            }

            foreach (string courseName in courseNames)
            {
                Console.WriteLine(courseName);
            }


        }

        public static int GetIdNumberFromUser()
        {
            Console.WriteLine("\nEnter Your ID number, only numbers :\n");
            int idnum = int.Parse(Console.ReadLine());
            return idnum;
        }

        public static void PrintStudent(StudentModel s)
        {
            Console.WriteLine(s);
        }

        public static StudentModel UpdateStudentFromUser()
        {

            StudentModel student = new StudentModel();

            Console.WriteLine("Insert First Name :");
            student.FirstName = Console.ReadLine();
            Console.WriteLine("Insert Last Name :");
            student.LastName = Console.ReadLine();
            Console.WriteLine("Insert Email :");
            student.Email = Console.ReadLine();
            Console.WriteLine("Insert Course Name :");
            student.CourseName = Console.ReadLine();
            Console.WriteLine("Insert Phone number :");
            student.Tel = Console.ReadLine();
            Console.WriteLine("Insert City :");
            student.City = Console.ReadLine();
            Console.WriteLine("Insert Address :");
            student.Address = Console.ReadLine();
            student.StartCourseDate = DateTime.Now;
            Console.WriteLine("Insert Grade Avg ,Only numbers 1-100:");
            student.GradeAvg = float.Parse(Console.ReadLine());

            Console.WriteLine("\nYour details have been successfully received");
            Console.WriteLine(student);
            return student;
        }

    }

}
