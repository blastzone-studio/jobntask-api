using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;

namespace JobNTask.Lib.Manager;

public class TaskManager
{
    private readonly ITaskRepository _taskRepository;

    public TaskManager(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void ProcessAction(ITaskAction action, ITaskTarget target, int quantity)
    {
        var tasks = _taskRepository.GetAllTasks()
                                   .Where(t => t.Action.Name == action.Name && t.Target.Name == target.Name)
                                   .ToList();

        foreach (var task in tasks)
        {
            task.UpdateProgress(quantity);

            if (task.IsCompleted())
            {
                Console.WriteLine($"Task {task.Id} is completed.");
            }
        }
    }
}
