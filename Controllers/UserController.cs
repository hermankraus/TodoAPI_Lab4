using Microsoft.AspNetCore.Mvc;
using TodoAPI.Entities;
using TodoAPI.Models;
using TodoAPI.Services.Implementations;
using TodoAPI.Models.TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO dto)
        {
            var user = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
            };
            int userId = _userService.CreateUser(user);
            return Ok(userId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User userToDelete = _userService.GetUserById(id);
            if (userToDelete == null)
            {
                return NotFound("Usuario no encontrado");
            }

            _userService.DeleteUser(userToDelete);
            return NoContent();
        }

        [HttpPost("{userId}/CreateTodoItems")]
        public IActionResult CreateTodoItem(int userId, [FromBody] TodoItemDTO dto)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var todoItem = new TodoItem()
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = userId
            };

            int todoItemId = _userService.CreateTodoItem(userId, todoItem);
            return Ok(todoItemId);
        }

        [HttpPut("{userId}/UpdateTodoItems/{todoItemId}")]
        public IActionResult UpdateTodoItem(int userId, int todoItemId, [FromBody] TodoItemDTO dto)
        {
            var todoItem = new TodoItem()
            {
                Id_todo_item = todoItemId,
                Title = dto.Title,
                Description = dto.Description,
                UserId = userId
            };
            bool success = _userService.UpdateTodoItem(userId, todoItem);
            if (!success)
            {
                return NotFound("Tarea no encontrada o no pertenece al usuario");
            }
            return NoContent();
        }

        [HttpDelete("{userId}/DeleteTodoItems/{todoItemId}")]
        public IActionResult DeleteTodoItem(int userId, int todoItemId)
        {
            bool success = _userService.DeleteTodoItem(userId, todoItemId);
            if (!success)
            {
                return NotFound("Tarea no encontrada o no pertenece al usuario");
            }
            return NoContent();
        }
    }
}
