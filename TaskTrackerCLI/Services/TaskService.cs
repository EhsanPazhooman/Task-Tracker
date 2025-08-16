using System.Text.Json;
using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public class TaskService : ITaskService
{
    private const string FilePath = "tasks.json";
     
    public void SaveTasks(List<TaskItem> tasks)
    {
        // Convert the C# object list into a JSON string
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        
        // Write that JSON string to a file 
        File.WriteAllText(FilePath, json);
    }

    public void AddTask(string Description)
    {
        var tasks = LoadAllTasks();
        var newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
        var now = DateTime.UtcNow;
        
        tasks.Add(new TaskItem
        {
            Id = newId,
            Description = Description,
            Status = "todo",
            CreatedAt = now
        });
        
        SaveTasks(tasks);

        Console.WriteLine($"Task added successfully => Id : {newId}");
    }

    public void UpdateTask(int Id, string Description)
    {
        var tasks = LoadAllTasks();
        
        var task = tasks.FirstOrDefault(t => t.Id == Id);

        if (task is null)
        {
            Console.WriteLine($"Task with Id {Id} not found");
            return;
        }
        
        task.Description = Description;
        
        SaveTasks(tasks);

        Console.WriteLine($"Task updated successfully => Id : {Id}");
    }

    public void DeleteTask(int Id)
    {
        var tasks = LoadAllTasks();
        
        var task = tasks.FirstOrDefault(t => t.Id == Id);
        
        if (task is null)
        {
            Console.WriteLine($"Task with Id {Id} not found");
            return;
        }
        
        tasks.Remove(task);

        SaveTasks(tasks);

        Console.WriteLine($"Task deleted successfully => Id : {Id}");
    }

    public void MarkInProgressTask(int Id)
    {
    }

    public void MarkDone(int Id)
    {
    }

    public List<TaskItem> LoadAllTasks()
    {
        if (!File.Exists(FilePath))
            return new List<TaskItem>();
        
        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }
}