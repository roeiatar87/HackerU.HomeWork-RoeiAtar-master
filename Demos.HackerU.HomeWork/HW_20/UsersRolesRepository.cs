using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.HackerU.HomeWork.HW_20
{
    public class UsersRolesRepository : IUsersRolesRepository
    {

        public User? Login(string userName, string password)
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                User? user = db.users.SingleOrDefault(x => x.UserName == userName && x.Password == password);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
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
                if (user != null)
                {
                    Role role = new Role();
                    role.RoleName = roleName;
                    user._roles.Add(role);
                    return UpdateUserRole(user);

                }

            }
            return false;

        }
        public bool RemoveUserFromRole(int id)
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                Role? role = db.roles.SingleOrDefault(x => x.Id == id);
                if (role != null)
                {
                    db.roles.Remove(role);
                    return db.SaveChanges() > 0;
                }
            }
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
