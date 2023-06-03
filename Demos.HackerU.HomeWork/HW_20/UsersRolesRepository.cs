using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_20
{
    public class UsersRolesRepository : IUsersRolesRepository
    {

        public User? Login(string userName, string password)
        {
            return new User();
        }
        public bool UserRegister(User user)
        {
            return false;
        }
        public bool AddUserToRole(User user)
        {
            return false;
        }
        public bool RemoveUserFromRole(int id)
        {
            return false;
        }
        public bool UpdateUserRole(User userToUpdate)
        {
            return false;
        }
        public List<string> GetAllUsersEmailsInRole()
        {
            return new List<string>();
        }
        public bool IsUserInRole(string userName)
        {
            return false;
        }

    }
}
