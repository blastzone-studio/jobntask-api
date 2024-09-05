using jobntask_lib.Model;

namespace jobntask_lib.Repository;

public interface IJobRepository
{
    void AddJob(IJob job);
    void RemoveJob(IJob job);
    IJob? GetJobById(string id);
    List<IJob> GetAllJobs();
}