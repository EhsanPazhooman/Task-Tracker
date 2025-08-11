using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public interface ITaskService
{
    List<TaskItem> LoadTasks();
    void SaveTasks();
    void AddTask(string Description);
}