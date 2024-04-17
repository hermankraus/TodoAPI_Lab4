using TodoAPI.dbContext;
using TodoAPI.Entities;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DbContextTodo _context;

        public UserService(DbContextTodo context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public int CreateTodoItem(int userId, TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
            return todoItem.Id_todo_item;
        }

        public bool UpdateTodoItem(int userId, TodoItem todoItem)
        {
            var existingTodoItem = _context.TodoItems.FirstOrDefault(t => t.UserId == userId && t.Id_todo_item == todoItem.Id_todo_item);
            if (existingTodoItem == null)
            {
                return false;
            }
            existingTodoItem.Title = todoItem.Title;
            existingTodoItem.Description = todoItem.Description;
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTodoItem(int userId, int todoItemId)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(t => t.UserId == userId && t.Id_todo_item == todoItemId);
            if (todoItem == null)
            {
                return false;
            }
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();
            return true;
        }
    }
}
