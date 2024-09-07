namespace JobNTask.Lib.Repository;

public interface ITaskWorkerRelationRepository
{
    void AddRelation(string taskId, string workerId);
    void RemoveRelation(string taskId, string workerId);
    string? GetWorkerIdByTaskId(string taskId);
    List<string> GetTasksByWorkerId(string workerId);
}