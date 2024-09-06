using JobNTask.Lib.Repository;
using JobNTask.Lib.Model;

namespace JobNTask.Lib.Service;

public class EnterpriseJobService
{
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IJobRepository _jobRepository;
    private readonly IEnterpriseJobRelationRepository _relationRepository;

    public EnterpriseJobService(IEnterpriseRepository enterpriseRepository, IJobRepository jobRepository, IEnterpriseJobRelationRepository relationRepository)
    {
        _enterpriseRepository = enterpriseRepository;
        _jobRepository = jobRepository;
        _relationRepository = relationRepository;
    }

    public void AddJobToEnterprise(string enterpriseId, IJob job)
    {
        _jobRepository.AddJob(job);
        _relationRepository.AddRelation(enterpriseId, job.Id);
    }

    public void RemoveJobFromEnterprise(string enterpriseId, string jobId)
    {
        _relationRepository.RemoveRelation(enterpriseId, jobId);
        _jobRepository.RemoveJob(_jobRepository.GetJobById(jobId));
    }

    public List<IJob> GetJobsForEnterprise(string enterpriseId)
    {
        var jobIds = _relationRepository.GetJobsByEnterpriseId(enterpriseId);
        return jobIds.Select(id => _jobRepository.GetJobById(id)).ToList();
    }

    public string GetEnterpriseForJob(string jobId)
    {
        return _relationRepository.GetEnterpriseByJobId(jobId);
    }
}