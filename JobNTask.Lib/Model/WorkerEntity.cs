namespace JobNTask.Lib.Model;


public class WorkerEntity : IWorkerEntity
{
    public string Id { get; private set; }

    public WorkerEntity(string id) 
    {
        Id = id;
    }
}