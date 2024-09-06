using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public interface IJobRepository
{
    void AddJob(IJob job);
    void RemoveJob(IJob job);
    IJob? GetJobById(string id);
    List<IJob> GetAllJobs();
}