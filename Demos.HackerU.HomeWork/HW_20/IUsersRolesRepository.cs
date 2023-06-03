namespace Demos.HackerU.HomeWork.HW_20



{
    public interface IUsersRolesRepository
    {
        public User? Login(string userName, string password);
        public void UserRegister(User user);
        public bool AddUserToRole(User user);
        public bool RemoveUserFromRole(int id);
        public bool UpdateUserRole(User userToUpdate);
        public List<string> GetAllUsersEmailsInRole();
        public bool IsUserInRole(string userName);
    }
}