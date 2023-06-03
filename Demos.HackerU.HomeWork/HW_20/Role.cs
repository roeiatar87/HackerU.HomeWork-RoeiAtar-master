using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_20
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }


        public List<User> _users { get; set; }
    }
}

