using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly Dictionary<string, ITask> _tasks = new Dictionary<string, ITask>();

    public void AddTask(ITask task)
    {
        if (!_tasks.ContainsKey(task.Id))
        {
            _tasks[task.Id] = task;
        }
    }

    public void RemoveTask(ITask task)
    {
        if (_tasks.ContainsKey(task.Id))
        {
            _tasks.Remove(task.Id);
        }
    }

    public ITask GetTaskById(string id)
    {
        _tasks.TryGetValue(id, out var task);
        return task;
    }

    public List<ITask> GetAllTasks()
    {
        return _tasks.Values.ToList();
    }
}