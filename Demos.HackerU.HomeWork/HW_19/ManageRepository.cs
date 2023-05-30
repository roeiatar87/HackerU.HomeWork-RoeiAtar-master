using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_19
{
    public class ManageRepository
    {

        private static ManageRepository Instance = null;
        private ManageRepository()
        {

        }

        public static ManageRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ManageRepository();
            }
            return Instance;
        }


        public int AddNewManager(Manager manager)
        {

            using (ManagingContext Db = new ManagingContext())
            {
                Db.managers.Add(manager);
                return Db.SaveChanges();
            }
        }

        public List<Manager> GetAllManagers()
        {
            var list = new List<Manager>();
            using (ManagingContext Db = new ManagingContext())
            {
                list = Db.managers.ToList();
                return list;
            }
        }

        public int DeletetManager(Manager manager)
        {

            using (ManagingContext Db = new ManagingContext())
            {
                Db.managers.Remove(manager);
                return Db.SaveChanges();
            }

        }

        public int AddNewEmployee(Employee employee)
        {

            using (ManagingContext Db = new ManagingContext())
            {
                Db.employees.Add(employee);
                return Db.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            using (ManagingContext Db = new ManagingContext())
            {
                list = Db.employees.ToList();
                return list;
            }
        }

        public int DeletetEmployee(Employee employee)
        {

            using (ManagingContext Db = new ManagingContext())
            {
                Db.employees.Remove(employee);
                return Db.SaveChanges();
            }

        }

    }
}
