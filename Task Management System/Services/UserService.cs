using System.Security.Claims;
using Task_Management_System.Interfaces;
using Task_Management_System.Models;

namespace Task_Management_System.Services
{
    public class UserService : IUserService
    {


        private readonly List<User> _users = new List<User>
    {
        new User { Username = "admin", Role = "Admin" },
        new User { Username = "user", Role = "User" }
    };

        public User Authenticate(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
        public UserService()
        {
        }

        public string? GetUserId()
        {
           // var user = Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            return "userUsername"; // Return the UserId or null if user is not found
         }

        public bool IsAdmin(string userId)
        {
           // username = userId;

            return true;
        }
    }
}
