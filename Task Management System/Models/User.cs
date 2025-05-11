using Microsoft.AspNetCore.Identity;

namespace Task_Management_System.Models
{
    public class User:IdentityUser
    {
        public string Id { get; set; } // Unique identifier
        public string Username { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
    }
}
