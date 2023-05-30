using Demos.HackerU.HomeWork.HW_18.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demos.HackerU.HomeWork.HW_18.Ef;
using Microsoft.Identity.Client;

namespace Demos.HackerU.HomeWork.HW_18
{
    public class HwRun
    {
        public static void Run()
        {


            ISudentRepository studentDb = new SudentDbRepository();
            StudentModel s1 = new StudentModel(1, "Matan", "gaida", "mt@gmail.com", "DAQ", "0505", "netanya", "sdfsdfssd", DateTime.Now, 90);
            StudentModel s2 = new StudentModel(1, "Matan", "gaida", "mt@gmail.com", "DAQ", "0505", "netanya", "sdfsdfssd", DateTime.Now, 70);
            StudentModel s3 = new StudentModel(32323, "galit", "galit", "mt@gmail.com", "DAQ", "0505", "netanya", "sdfsdfssd", DateTime.Now, 100);
            StudentModel s4 = new StudentModel(1, "Roei", "Atar", "mt@gmail.com", "DAQ", "0505", "Ashkelon", "sdfsdfssd", DateTime.Now, 20);

            //StudentModel[] all = { s1, s2, s3, s4 };
            //for (int i = 0; i < all.Length; i++)
            //{
            //    studentRepo.AddNewStudent(all[i]);
            //}

            // var list = studentRepo.GetAllStudents();

            //studentDb.DeleteStudentByID(301325528);

            //var s5 = studentRepo.GetAllStudentsByCourse("DAQ");

            //var s6 = studentDb.GetStudentByID(301325528);

            //studentDb.UpdateStudentByID(32323, s3);



            // var StudentEf = SudentEfRepository.GetInstance();
            //StudentEf.AddNewStudent(s4);
            // StudentEf.AddNewStudent(s3);
            // StudentEf.AddNewStudent(s2);
            // StudentEf.AddNewStudent(s1);

            // StudentEf.GetAllStudentsByCourse("DAQ");
            // StudentEf.GetStudentByID(3);
            // StudentEf.UpdateStudentByID(3, s4);
            //StudentEf.DeleteStudentByID(15);
            // var listEf = StudentEf.GetAllStudents();



            Menu.Display();
        }


    }
}
