using Demos.HackerU.HomeWork.Inhheritance;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_19
{
    public class ManageOperations
    {

        public static void Run()
        {

            ManageRepository obj = ManageRepository.GetInstance();

            Manager m1 = new Manager { Name = "Roei" };
            m1.employeesList = new List<Employee>()
            {
                new Employee {Name ="david" },
                new Employee {Name ="Moshe"},
                 new Employee {Name ="Matan" },
                new Employee {Name ="avShalom"},

            };

            Manager m3 = new Manager { Name = "barak" };
            m3.employeesList = new List<Employee>()
            {
                new Employee {Name ="david" },
                new Employee {Name ="avraham"},
                 new Employee {Name ="dvir" },
                new Employee {Name ="dolev"},

            };

            Employee e1 = new Employee { Name = "Lior" };
            e1.managerss = new List<Manager>
            {
                new Manager {Name ="oren"},
                new Manager {Name ="saad"},
                new Manager {Name ="barak"}
            };

            //Blog b = db.Blogs.Include(b => b.Posts).ThenInclude(p => p.Tags).SingleOrDefault(b => b.Id == 1003);
            //obj.AddNewManager(m1);


            obj.AddNewEmployee(e1);
            //ManagingContext db = new ManagingContext();
            //Manager m2 = db.managers.Include(m => m.employeesList).SingleOrDefault(m => m.Id == 1);

            // var item = obj.GetAllManagers();




        }
    }
}
