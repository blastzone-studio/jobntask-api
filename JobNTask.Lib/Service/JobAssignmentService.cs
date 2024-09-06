using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;

namespace JobNTask.Lib.Service;

public class JobAssignmentService
{
    private readonly IEnterpriseJobRelationRepository _enterpriseJobRelationRepository;
    private readonly IJobWorkerRelationRepository _jobWorkerRelationRepository;
    private readonly IJobRepository _jobRepository;
    private readonly IWorkerRepository<IWorkerEntity> _workerRepository;
    private readonly IEnterpriseRepository _enterpriseRepository;

    public JobAssignmentService(IEnterpriseJobRelationRepository enterpriseJobRelationRepository, 
                                IJobWorkerRelationRepository jobWorkerRelationRepository,
                                IJobRepository jobRepository,
                                IWorkerRepository<IWorkerEntity> workerRepository,
                                IEnterpriseRepository enterpriseRepository)
    {
        _enterpriseJobRelationRepository = enterpriseJobRelationRepository;
        _jobWorkerRelationRepository = jobWorkerRelationRepository;
        _jobRepository = jobRepository;
        _workerRepository = workerRepository;
        _enterpriseRepository = enterpriseRepository;
    }

    public void AssignJobToEnterprise(string jobId, string enterpriseId)
    {
        var job = _jobRepository.GetJobById(jobId);
        var enterprise = _enterpriseRepository.GetEnterpriseById(enterpriseId);

        if (job != null && enterprise != null)
        {
            _enterpriseJobRelationRepository.AddRelation(enterpriseId, jobId);
        }
    }

    public void AssignWorkerToJob(string jobId, string workerId)
    {
        var job = _jobRepository.GetJobById(jobId);
        var worker = _workerRepository.GetWorkerById(workerId);

        if (job != null && worker != null)
        {
            _jobWorkerRelationRepository.AddRelation(jobId, workerId);
        }
    }

    public string GetEnterpriseForJob(string jobId)
    {
        return _enterpriseJobRelationRepository.GetEnterpriseByJobId(jobId);
    }

    public string GetWorkerForJob(string jobId)
    {
        return _jobWorkerRelationRepository.GetWorkerByJobId(jobId);
    }
}