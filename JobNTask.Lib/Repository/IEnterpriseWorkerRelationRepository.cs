namespace JobNTask.Lib.Repository;

public interface IEnterpriseWorkerRelationRepository
{
    void AddRelation(string enterpriseId, string workerId);
    void RemoveRelation(string enterpriseId, string workerId);
    List<string> GetWorkersByEnterpriseId(string enterpriseId);
    List<string> GetEnterprisesByWorkerId(string workerId);
}