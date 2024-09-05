using jobntask_lib.Model;

namespace jobntask_lib.Repository;

public class InMemoryJobRepository : IJobRepository
{
    private readonly Dictionary<string, IJob> _jobs = new Dictionary<string, IJob>();

    public void AddJob(IJob job)
    {
        _jobs[job.Id] = job;
    }

    public void RemoveJob(IJob job)
    {
        _jobs.Remove(job.Id);
    }

    public IJob? GetJobById(string id)
    {
        _jobs.TryGetValue(id, out var job);
        return job;
    }

    public List<IJob> GetAllJobs()
    {
        return _jobs.Values.ToList();
    }
}