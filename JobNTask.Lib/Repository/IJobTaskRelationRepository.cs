namespace JobNTask.Lib.Repository;

public interface IJobTaskRelationRepository
{
    void AddRelation(string jobId, string taskId);
    void RemoveRelation(string jobId, string taskId);
    List<string> GetTasksByJobId(string jobId);
    string GetJobByTaskId(string taskId);
}