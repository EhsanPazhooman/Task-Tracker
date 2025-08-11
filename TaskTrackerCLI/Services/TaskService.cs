namespace TaskTrackerCLI.Services;

public class TaskService
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}