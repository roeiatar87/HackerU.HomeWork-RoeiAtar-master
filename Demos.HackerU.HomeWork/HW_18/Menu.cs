using Demos.HackerU.HomeWork.HW_18.Db;
using Demos.HackerU.HomeWork.HW_18.Ef;
using Demos.HackerU.HomeWork.Inhheritance;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demos.HackerU.HomeWork.HW_18
{
    public class Menu
    {
        public static void Display()
        {
            string select = SQLMenu();
            MenuManager(select);
        }


        private static void MenuManager(string select)
        {
            bool isContinue = true;
            while (isContinue)
            {
                isContinue = MainMenu(select);
            }
        }

        public static string SQLMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) SQL-DataReader");
            Console.WriteLine("2) SQL-EntityFramework");
            bool isContinue = true;
            string select = null;


            while (isContinue)
            {

                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        isContinue = false;
                        break;
                    case "2":
                        isContinue = false;
                        break;
                    default:
                        isContinue = true;
                        Console.WriteLine("Choose an option:");
                        break;
                }

            }
            return select;

        }

        private static bool SQLEf(SudentEfRepository s)
        {
            Console.WriteLine("SQL-EntityFramework");
            MenuSelect();
            switch (Console.ReadLine())
            {
                case "1":
                    s.AddNewStudent(ConsoleService.GetStudentFromUser());
                    Console.WriteLine("\nStudent successfully Add\n");
                    return true;
                case "2":
                    ConsoleService.PrintAllStudents(s.GetAllStudents());
                    return true;
                case "3":
                    ConsoleService.PrintAllStudents(s.GetAllStudentsByCourse(ConsoleService.GetCourseNameFromUser(s.GetAllStudents())));
                    return true;
                case "4":
                    ConsoleService.PrintStudent(s.GetStudentByID(ConsoleService.GetIdNumberFromUser()));
                    return true;
                case "5":
                    s.UpdateStudentByID(ConsoleService.GetIdNumberFromUser(), ConsoleService.UpdateStudentFromUser());
                    Console.WriteLine("\nStudent successfully Updated\n");
                    return true;
                case "6":
                    s.DeleteStudentByID(ConsoleService.GetIdNumberFromUser());
                    Console.WriteLine("\nStudent successfully Removed\n");
                    return true;
                case "7":
                    return false;
                case "8":
                    Display();
                    return false;
                case "9":
                    return false;
                default:
                    return true;
            }
        }

        private static bool SQLDB(SudentDbRepository s)
        {
            Console.WriteLine("SQL-DataReader");
            MenuSelect();
            switch (Console.ReadLine())
            {
                case "1":
                    s.AddNewStudent(ConsoleService.GetStudentFromUser());
                    Console.WriteLine("\nStudent successfully Add\n");
                    return true;
                case "2":
                    ConsoleService.PrintAllStudents(s.GetAllStudents());
                    return true;
                case "3":
                    ConsoleService.PrintAllStudents(s.GetAllStudentsByCourse(ConsoleService.GetCourseNameFromUser(s.GetAllStudents())));
                    return true;
                case "4":
                    ConsoleService.PrintStudent(s.GetStudentByID(ConsoleService.GetIdNumberFromUser()));
                    return true;
                case "5":
                    s.UpdateStudentByID(ConsoleService.GetIdNumberFromUser(), ConsoleService.UpdateStudentFromUser());
                    Console.WriteLine("\nStudent successfully Updated\n");
                    return true;
                case "6":
                    s.DeleteStudentByID(ConsoleService.GetIdNumberFromUser());
                    Console.WriteLine("\nStudent successfully Removed\n");
                    return true;
                case "7":
                    return false;
                case "8":
                    Display();
                    return false;
                case "9":
                    return false;
                default:
                    return true;
            }
        }


        public static bool MainMenu(string select)
        {
            //ISudentRepository studentDb = new SudentDbRepository();
            //var StudentEf = SudentEfRepository.GetInstance();

            switch (select)
            {
                case "1":
                    return SQLDB(new SudentDbRepository());
                case "2":
                    return SQLEf(SudentEfRepository.GetInstance());
                default: return true;

            }

        }

        private static void MenuSelect()
        {
            Console.WriteLine("_________________________");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Insert New Student");
            Console.WriteLine("2) Show All Students");
            Console.WriteLine("3) Show Students in the same Course and grade avg in course");
            Console.WriteLine("4) Get Student By Id");
            Console.WriteLine("5) Update Student By ID");
            Console.WriteLine("6) Delete Student By ID");
            Console.WriteLine("7) Save Last Result to JSON File");
            Console.WriteLine("8) Return to SQL Select Menu");
            Console.WriteLine("9) Exit");
        }
    }


}
