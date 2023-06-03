﻿namespace Demos.HackerU.HomeWork.HW_20



{
    public interface IUsersRolesRepository
    {
        public User? Login(string userName, string password);
        public bool UserRegister(string name, string password, string email, string rolename);
        public bool AddUserToRole(int id, string roleName);
        public bool RemoveUserFromRole(int id);
        public bool UpdateUserRole(User userToUpdate);
        public List<string> GetAllUsersEmailsInRole();
        public bool IsUserInRole(string userName);

        public List<User> GetAllUsers();
    }
}