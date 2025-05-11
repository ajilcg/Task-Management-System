using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Data;
using Task_Management_System.Dtos;
using Task_Management_System.Interfaces;

namespace Task_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _context;
        private readonly IUserService _userService; // Service to handle user info

        public TasksController(TaskDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto taskDto)
        {
            //var userId = _userService.GetUserId();
            var userId = "Admin";
            var task = new Models.Task
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                OwnerUserId = userId
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto taskDto)
        {
            var userId = "Admin";
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || task.OwnerUserId != userId)
            {
                return NotFound();
            }
            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.DueDate = taskDto.DueDate;
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetTasks()
        {
            var userId = "Admin";

            var tasks = await _context.Tasks
                .Where(t => t.OwnerUserId == userId || _userService.IsAdmin(userId)).ToListAsync();

            return Ok(tasks);
        }
        [HttpPatch("{id}/complete")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> MarkTaskAsCompleted(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return Ok(task);
        }

         [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || (task.OwnerUserId != _userService.GetUserId() && !_userService.IsAdmin(_userService.GetUserId())))
            {
                return NotFound();
            }
            return Ok(task);
        }
    }

}

