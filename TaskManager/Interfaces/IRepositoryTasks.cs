using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface IRepositoryTasks
{
    public List<Todo> Todos { get; }

    public List<Todo> GetAllTodos();

    public void AddTodo(Todo task);

    public void UpdateTodo(Todo task);

    public void DeleteTodo(Guid Id);

    public Todo GetById(Guid Id);
}