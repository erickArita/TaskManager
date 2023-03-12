using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Services;

public class RepositotyTasks : IRepositoryTasks
{
    public List<Todo> Todos { get; }

    public RepositotyTasks()
    {
        Todos = new List<Todo>();
    }

    public List<Todo> GetAllTodos()
    {
        return Todos;
    }

    public void AddTodo(Todo task)
    {
        task.Id = Guid.NewGuid();
        Todos.Add(task);
    }

    public void UpdateTodo(Todo task)
    {
        var todo = Todos.FirstOrDefault(todo => todo.Id == task.Id);

        if (todo == null)
            throw new Exception("No existe la tarea");

        todo.Title = task.Title;
        todo.Description = task.Description;
        todo.EndDate = task.EndDate;
    }

    public void DeleteTodo(Guid Id)
    {
        var todo = Todos.FirstOrDefault(todo => todo.Id == Id);

        if (todo == null)
            throw new Exception("No existe la tarea");

        Todos.Remove(todo);
    }

    public Todo GetById(Guid Id)
    {
        var todo = Todos.FirstOrDefault(todo => todo.Id == Id);

        if (todo == null)
            throw new Exception("No existe la tarea");
        return todo;
    }
}