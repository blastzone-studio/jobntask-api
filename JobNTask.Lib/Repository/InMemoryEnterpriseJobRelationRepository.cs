using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryEnterpriseJobRelationRepository : IEnterpriseJobRelationRepository
{
    private readonly List<EnterpriseJobRelation> _relations = new List<EnterpriseJobRelation>();

    public void AddRelation(string enterpriseId, string jobId)
    {
        if (!_relations.Any(r => r.EnterpriseId == enterpriseId && r.JobId == jobId))
        {
            _relations.Add(new EnterpriseJobRelation(enterpriseId, jobId));
        }
    }

    public void RemoveRelation(string enterpriseId, string jobId)
    {
        var relation = _relations.FirstOrDefault(r => r.EnterpriseId == enterpriseId && r.JobId == jobId);
        if (relation != null)
        {
            _relations.Remove(relation);
        }
    }

    public List<string> GetJobsIdByEnterpriseId(string enterpriseId)
    {
        return _relations
            .Where(r => r.EnterpriseId == enterpriseId)
            .Select(r => r.JobId)
            .ToList();
    }

    public string? GetEnterpriseIdByJobId(string jobId)
    {
        return _relations
            .Where(r => r.JobId == jobId)
            .Select(r => r.EnterpriseId)
            .FirstOrDefault();
    }
}