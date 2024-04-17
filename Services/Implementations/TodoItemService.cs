using TodoAPI.dbContext;
using TodoAPI.Entities;
using TodoAPI.Services.Interfaces.TodoAPI.Services;

namespace TodoAPI.Services.Implementations
{
    public class TodoItemService : ITodoItemService
    {
        private readonly DbContextTodo _context;
        public TodoItemService(DbContextTodo context)
        {
            _context = context;
        }

        public TodoItem GetItemById(int Id) => _context.TodoItems.FirstOrDefault(p => p.Id_todo_item == Id);

        public IEnumerable<TodoItem> GetAllItems() => _context.TodoItems.ToList();

        public IEnumerable<TodoItem> GetItemsByUserId(int userId) => _context.TodoItems.Where(t => t.UserId == userId).ToList();
    }
}
