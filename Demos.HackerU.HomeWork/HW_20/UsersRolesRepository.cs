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
                    user._roles = new List<Role>() { new Role { RoleName = roleName } };
                    db.users.Update(user);
                    return db.SaveChanges() > 0;
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
        public bool UpdateUserRole(int id, string rolename, string roleToUpdate)
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                Role? role = db.roles.SingleOrDefault(x => x.RoleName == rolename && x.Id == id);

                if (role != null)
                {
                    role.RoleName = roleToUpdate;
                    db.roles.Update(role);
                }
                return db.SaveChanges() > 0;
            }
        }
        public List<string> GetAllUsersEmailsInRole(string roleName)
        {
            List<string> emails = new List<string>();
            using (UsersDbContext db = new UsersDbContext())
            {
                List<Role> roles = db.roles.Where(x => x.RoleName == roleName).ToList();

                foreach (Role role in roles)
                {
                    foreach (User user in db.users)
                    {
                        if (user.Id == role.Id)
                        {
                            emails.Add(user.Email);
                        }
                    }
                }

                return emails;
            }
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
