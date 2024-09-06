using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryEnterpriseWorkerRelationRepository : IEnterpriseWorkerRelationRepository
{
    private readonly List<EnterpriseWorkerRelation> _relations = new List<EnterpriseWorkerRelation>();

    public void AddRelation(string enterpriseId, string workerId)
    {
        if (!_relations.Any(r => r.EnterpriseId == enterpriseId && r.WorkerId == workerId))
        {
            _relations.Add(new EnterpriseWorkerRelation(enterpriseId, workerId));
        }
    }

    public void RemoveRelation(string enterpriseId, string workerId)
    {
        var relation = _relations.FirstOrDefault(r => r.EnterpriseId == enterpriseId && r.WorkerId == workerId);
        if (relation != null)
        {
            _relations.Remove(relation);
        }
    }

    public List<string> GetWorkersByEnterpriseId(string enterpriseId)
    {
        return _relations
            .Where(r => r.EnterpriseId == enterpriseId)
            .Select(r => r.WorkerId)
            .ToList();
    }

    public List<string> GetEnterprisesByWorkerId(string workerId)
    {
        return _relations
            .Where(r => r.WorkerId == workerId)
            .Select(r => r.EnterpriseId)
            .ToList();
    }
}