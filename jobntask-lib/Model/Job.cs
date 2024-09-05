namespace jobntask_lib.Model;

public class Job : IJob
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<ITask> Tasks { get; private set; }

    public Job(string id, string name)
    {
        Id = id;
        Name = name;
        Tasks = new List<ITask>();
    }

    public void AddTask(ITask task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(ITask task)
    {
        Tasks.Remove(task);
    }
}