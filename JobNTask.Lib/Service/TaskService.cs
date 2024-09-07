using JobNTask.Lib.Repository;
using JobNTask.Lib.Model;

namespace JobNTask.Lib.Service;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public void CreateTask(string id, string description, ITaskAction action, int requiredQuantity, ITaskTarget target)
    {
        var task = new Model.Task(id, description, action, requiredQuantity, target);
        _taskRepository.AddTask(task);
    }

    public void DeleteTask(string id)
    {
        var task = _taskRepository.GetTaskById(id);
        if (task != null)
        {
            _taskRepository.RemoveTask(task);
        }
    }

    public ITask? GetTask(string id)
    {
        return _taskRepository.GetTaskById(id);
    }

    public List<ITask> GetAllTasks()
    {
        return _taskRepository.GetAllTasks();
    }
}