namespace TaskManager.Models;

public class Todo
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String Description { get; set; }
    public DateTime EndDate { get; set; }
}