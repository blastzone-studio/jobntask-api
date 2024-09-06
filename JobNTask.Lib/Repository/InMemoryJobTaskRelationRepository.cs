using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryJobTaskRelationRepository : IJobTaskRelationRepository
{
    private readonly List<JobTaskRelation> _relations = new List<JobTaskRelation>();

    public void AddRelation(string jobId, string taskId)
    {
        if (!_relations.Any(r => r.JobId == jobId && r.TaskId == taskId))
        {
            _relations.Add(new JobTaskRelation(jobId, taskId));
        }
    }

    public void RemoveRelation(string jobId, string taskId)
    {
        var relation = _relations.FirstOrDefault(r => r.JobId == jobId && r.TaskId == taskId);
        if (relation != null)
        {
            _relations.Remove(relation);
        }
    }

    public List<string> GetTasksByJobId(string jobId)
    {
        return _relations
            .Where(r => r.JobId == jobId)
            .Select(r => r.TaskId)
            .ToList();
    }

    public string GetJobByTaskId(string taskId)
    {
        return _relations
            .Where(r => r.TaskId == taskId)
            .Select(r => r.JobId)
            .FirstOrDefault();
    }
}