using TodoAPI.Entities;

namespace TodoAPI.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        int CreateUser(User user);
        void DeleteUser(User user);
        int CreateTodoItem(int userId, TodoItem todoItem);
        bool UpdateTodoItem(int userId, TodoItem todoItem);
        bool DeleteTodoItem(int userId, int todoItemId);
    }
}
