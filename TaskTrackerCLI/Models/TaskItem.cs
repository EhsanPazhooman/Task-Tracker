namespace TaskTrackerCLI.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}