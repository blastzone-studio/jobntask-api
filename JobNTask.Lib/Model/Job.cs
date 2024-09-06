namespace JobNTask.Lib.Model;

public class Job : IJob
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<ITask> Tasks { get; private set; }
    public IEnterprise Enterprise { get; private set; }
    public IWorkerEntity? AssignedWorker { get; private set; }
    
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

    public void AssignWorker(IWorkerEntity worker)
    {
        AssignedWorker = worker;
    }

    public void AssignToEnterprise(IEnterprise enterprise)
    {
        Enterprise = enterprise;
    }
}