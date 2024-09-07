namespace JobNTask.Lib.Repository;

public interface IJobWorkerRelationRepository
{
    void AddRelation(string jobId, string workerId);
    void RemoveRelation(string jobId, string workerId);
    string? GetWorkerIdByJobId(string jobId);
    List<string> GetJobsByWorkerId(string workerId);
}