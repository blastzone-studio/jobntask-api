using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryJobWorkerRelationRepository : IJobWorkerRelationRepository
{
    private readonly List<JobWorkerRelation> _relations = new List<JobWorkerRelation>();

    public void AddRelation(string jobId, string workerId)
    {
        if (!_relations.Any(r => r.JobId == jobId && r.WorkerId == workerId))
        {
            _relations.Add(new JobWorkerRelation(jobId, workerId));
        }
    }

    public void RemoveRelation(string jobId, string workerId)
    {
        var relation = _relations.FirstOrDefault(r => r.JobId == jobId && r.WorkerId == workerId);
        if (relation != null)
        {
            _relations.Remove(relation);
        }
    }

    public string? GetWorkerIdByJobId(string jobId)
    {
        return _relations.FirstOrDefault(r => r.JobId == jobId)?.WorkerId;
    }

    public List<string> GetJobsByWorkerId(string workerId)
    {
        return _relations
            .Where(r => r.WorkerId == workerId)
            .Select(r => r.JobId)
            .ToList();
    }
}