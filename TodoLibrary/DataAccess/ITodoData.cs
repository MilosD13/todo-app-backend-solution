using TodoLibrary.Models;

namespace TodoLibrary.DataAccess
{
    public interface ITodoData
    {
        Task CompleteTodo(int assignedTo, int todoId);
        Task<TodoModel?> Create(int assignedTo, string task);
        Task Delete(int assignedTo, int todoId);
        Task<List<TodoModel>> GetAll(int assignedTo);
        Task<TodoModel?> GetOne(int assignedTo, int todoId);
        Task UpdateTask(int assignedTo, int todoId, string task);
    }
}