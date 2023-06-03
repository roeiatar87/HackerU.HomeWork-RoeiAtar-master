using Microsoft.EntityFrameworkCore;
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
        public bool UserRegister(string name, string password, string email, string rolename)
        {
            User user = new User();
            user.UserName = name;
            user.Password = password;
            user.Email = email;
            user._roles = new List<Role>() { new Role { RoleName = rolename } };
            using (UsersDbContext db = new UsersDbContext())
            {
                db.users.Add(user);
                return db.SaveChanges() > 0;
            }
        }

        public bool AddUserToRole(int id, string roleName)
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                User? user = db.users.SingleOrDefault(x => x.Id == id);
                if (user == null)
                {
                    user._roles.Add(new Role { RoleName = roleName });
                    UpdateUserRole(user);
                }
                return db.SaveChanges() > 0;
            }

        }
        public bool RemoveUserFromRole(int id)
        {
            return false;
        }
        public bool UpdateUserRole(User userToUpdate)
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                db.users.Update(userToUpdate);
                return db.SaveChanges() > 0;
            }
        }
        public List<string> GetAllUsersEmailsInRole()
        {
            return new List<string>();
        }
        public bool IsUserInRole(string userName)
        {
            return false;
        }

        public List<User> GetAllUsers()
        {
            var list = new List<User>();
            using (UsersDbContext db = new UsersDbContext())
            {
                list = db.users.ToList();
            }
            return list;

        }
    }
}
