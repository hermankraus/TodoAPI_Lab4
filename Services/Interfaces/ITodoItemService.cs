using TodoAPI.Entities;

namespace TodoAPI.Services.Interfaces.TodoAPI.Services
{
    public interface ITodoItemService
    {
        TodoItem GetItemById(int Id);
        IEnumerable<TodoItem> GetAllItems();
        IEnumerable<TodoItem> GetItemsByUserId(int userId);
    }
}
