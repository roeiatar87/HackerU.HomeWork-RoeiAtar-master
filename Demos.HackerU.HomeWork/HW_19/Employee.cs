using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_19
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Manager> managerss { get; set; }
    }
}
