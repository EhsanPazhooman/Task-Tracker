

using TaskTrackerCLI.Models;
using TaskTrackerCLI.Services;

namespace TaskTrackerCLI
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return;
            }

            var service = new TaskService();
            var command = args[0].ToLower();

            try
            {
                switch (command)
                {
                    case "add":
                        if(args.Length < 2) throw new ArgumentException("Description Required");
                        service.AddTask(args[1]);
                        break;
                    
                    case "update":
                        if (args.Length < 3) throw new ArgumentException("Id and Description Required");
                        if (!int.TryParse(args[1], out int updateId)) throw new ArgumentException("Invalid Id");
                        service.UpdateTask(updateId, args[2]);
                        break;
                    
                    case "delete":
                        if (args.Length < 2) throw new ArgumentException("Id Required");
                        if (!int.TryParse(args[1], out int deleteId)) throw new ArgumentException("Invalid Id");
                        service.DeleteTask(deleteId);
                        break;
                    
                    case "mark-in-progress":
                        if (args.Length < 2) throw new ArgumentException("Id Required");
                        if (!int.TryParse(args[1], out int markInProgressId)) throw new ArgumentException("Invalid Id");
                        service.MarkInProgressTask(markInProgressId);
                        break;
                    
                    case "mark-done":
                        if (args.Length < 2) throw new ArgumentException("Id Required");
                        if (!int.TryParse(args[1], out int doneId)) throw new ArgumentException("Invalid Id");
                        service.MarkDone(doneId);
                        break;
                    
                    case "list":
                        if (args.Length == 1)
                        {
                            PrintTasks(service.LoadAllTasks());
                        }
                        else if (args.Length == 2)
                        {
                            var status = args[1].ToLower();
                            if (status == "done" || status == "todo" || status == "in-progress")
                            {
                                PrintTasks(service.GetTasksByStatus(status));
                            }
                            else
                            {
                                throw new ArgumentException("Invalid status. Use: done, todo, in-progress.");
                            }
                        }
                        break;

                    default:
                        PrintUsage();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private static void PrintTasks(List<TaskItem> tasks)
        {
            if (!tasks.Any())
            {
                Console.WriteLine("No tasks found");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"Id: {task.Id} | Description: {task.Description} | Status: {task.Status}");
                Console.WriteLine($"Created : {task.CreatedAt:yyyy-MM-dd HH:mm}");
                Console.WriteLine("----");
            }
        }
        private static void PrintUsage()
        {
            Console.WriteLine("Task Tracker CLI Usage:");
            Console.WriteLine("  add \"description\"          - Add a new task");
            Console.WriteLine("  update <id> \"description\"   - Update existing task");
            Console.WriteLine("  delete <id>                 - Delete a task");
            Console.WriteLine("  mark-in-progress <id>       - Mark task as in progress");
            Console.WriteLine("  mark-done <id>              - Mark task as done");
            Console.WriteLine("  list                        - List all tasks");
            Console.WriteLine("  list done                   - List completed tasks");
            Console.WriteLine("  list todo                   - List pending tasks");
            Console.WriteLine("  list in-progress            - List tasks in progress");
        }
    }
}

