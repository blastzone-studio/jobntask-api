namespace JobNTask.Lib.Repository;

public interface IEnterpriseJobRelationRepository
{
    void AddRelation(string enterpriseId, string jobId);
    void RemoveRelation(string enterpriseId, string jobId);
    List<string> GetJobsIdByEnterpriseId(string enterpriseId);
    string? GetEnterpriseIdByJobId(string jobId);
}