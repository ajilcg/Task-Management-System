﻿namespace Task_Management_System.Dtos
{
    public class UpdateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
