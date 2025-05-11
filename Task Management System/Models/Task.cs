namespace Task_Management_System.Models
{
    public class Task
    {
        public int Id { get; set; } // Unique identifier
        public string Title { get; set; } // Required
        public string Description { get; set; } // Optional
        public bool IsCompleted { get; set; } = false; // Defaults to false
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set
        public DateTime? DueDate { get; set; } // Optional
        public string OwnerUserId { get; set; } // Foreign key to User
    }
}
