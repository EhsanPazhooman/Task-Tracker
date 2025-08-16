using TaskTrackerCLI.Models;

namespace TaskTrackerCLI.Services;

public interface ITaskService
{
    void SaveTasks(List<TaskItem> tasks);
    void AddTask(string Description);
    void UpdateTask(int Id, string Description);
    void DeleteTask(int Id);
    void MarkInProgressTask(int Id);
    void MarkDone(int Id);
    List<TaskItem> LoadAllTasks();
}