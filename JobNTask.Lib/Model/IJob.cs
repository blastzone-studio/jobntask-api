namespace JobNTask.Lib.Model;

public interface IJob
{
    string Id { get; }
    string Name { get; }
    IEnterprise Enterprise { get; }
    IWorkerEntity? AssignedWorker { get; }
    List<ITask> Tasks { get; }

    void AssignToEnterprise(IEnterprise enterprise);
    void AssignWorker(IWorkerEntity worker);
    void AddTask(ITask task);
    void RemoveTask(ITask task);
}
