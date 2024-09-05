namespace jobntask_lib.Model;

public interface IJob
{
    string Id { get; }
    string Name { get; }
    List<ITask> Tasks { get; }

    void AddTask(ITask task);
    void RemoveTask(ITask task);
}
