namespace JobNTask.Lib.Repository;

public interface IEnterpriseJobRelationRepository
{
    void AddRelation(string enterpriseId, string jobId);
    void RemoveRelation(string enterpriseId, string jobId);
    List<string> GetJobsByEnterpriseId(string enterpriseId);
    string GetEnterpriseByJobId(string jobId);
}