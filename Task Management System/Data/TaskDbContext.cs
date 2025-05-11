using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task_Management_System.Models;

namespace Task_Management_System.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
