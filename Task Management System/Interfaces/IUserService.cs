using Task_Management_System.Models;

namespace Task_Management_System.Interfaces
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAdmin(string userId);
        public User Authenticate(string username);

    }
}
