using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryTaskWorkerRelationRepository : ITaskWorkerRelationRepository
{
    private readonly List<TaskWorkerRelation> _relations = new List<TaskWorkerRelation>();

    public void AddRelation(string taskId, string workerId)
    {
        if (!_relations.Any(r => r.TaskId == taskId && r.WorkerId == workerId))
        {
            _relations.Add(new TaskWorkerRelation(taskId, workerId));
        }
    }

    public void RemoveRelation(string taskId, string workerId)
    {
        var relation = _relations.FirstOrDefault(r => r.TaskId == taskId && r.WorkerId == workerId);
        if (relation != null)
        {
            _relations.Remove(relation);
        }
    }

    public string? GetWorkerIdByTaskId(string taskId)
    {
        return _relations.FirstOrDefault(r => r.TaskId == taskId)?.WorkerId;
    }

    public List<string> GetTasksByWorkerId(string workerId)
    {
        return _relations
            .Where(r => r.WorkerId == workerId)
            .Select(r => r.TaskId)
            .ToList();
    }
}