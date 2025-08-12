using System.Text.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public class TaskService : ITaskService
{
    private const string FilePath = "tasks.json";
     
    public void SaveTasks(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public void AddTask(string Description)
    {
    }

    public void UpdateTask(int Id, string Description)
    {
    }

    public void DeleteTask(int Id)
    {
    }

    public void MarkInProgressTask(int Id)
    {
    }

    public void MarkDone(int Id)
    {
    }

    public List<TaskItem> GetAllTasks()
    {
        if (!File.Exists(FilePath))
            return new List<TaskItem>();
        
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }
}