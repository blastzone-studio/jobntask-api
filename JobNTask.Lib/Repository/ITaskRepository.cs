using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public interface ITaskRepository
{
    void AddTask(ITask job);
    void RemoveTask(ITask job);
    ITask? GetTaskById(string id);
    List<ITask> GetAllTasks();
}