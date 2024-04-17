using Microsoft.AspNetCore.Mvc;
using TodoAPI.Entities;
using TodoAPI.Models;
using TodoAPI.Services.Interfaces.TodoAPI.Services;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("{id}/GetItemById")]
        public IActionResult GetItemById(int id)
        {
            var item = _todoItemService.GetItemById(id);
            if (item == null)
            {
                return NotFound("No existe esta tarea");
            }
            return Ok(item);
        }

        [HttpGet("all")]
        public IActionResult GetAllItems()
        {
            var items = _todoItemService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("user/{userId}/GetItemByUserId")]
        public IActionResult GetItemsByUserId(int userId)
        {
            var items = _todoItemService.GetItemsByUserId(userId);
            return Ok(items);
        }
    }
}
