using JobNTask.Lib.Repository;
using JobNTask.Lib.Model;

namespace JobNTask.Lib.Service;

public class EnterpriseService
{
    private readonly IEnterpriseRepository _enterpriseRepository;
    private readonly IEnterpriseWorkerRelationRepository _relationRepository;
    private readonly IWorkerRepository<IWorkerEntity> _workerRepository;
    private readonly IJobRepository _jobRepository;
    private readonly IEnterpriseJobRelationRepository _enterpriseJobRelationRepository;

    public EnterpriseService(IEnterpriseRepository enterpriseRepository, 
                             IEnterpriseWorkerRelationRepository relationRepository,
                             IWorkerRepository<IWorkerEntity> workerRepository,
                             IJobRepository jobRepository,
                             IEnterpriseJobRelationRepository enterpriseJobRelationRepository)
    {
        _enterpriseRepository = enterpriseRepository;
        _relationRepository = relationRepository;
        _workerRepository = workerRepository;
        _jobRepository = jobRepository;
        _enterpriseJobRelationRepository = enterpriseJobRelationRepository;
    }

    public void AddWorkerToEnterprise(string enterpriseId, IWorkerEntity worker)
    {
        _relationRepository.AddRelation(enterpriseId, worker.Id);
    }

    public void RemoveWorkerFromEnterprise(string enterpriseId, IWorkerEntity worker)
    {
        _relationRepository.RemoveRelation(enterpriseId, worker.Id);
    }

    public List<IWorkerEntity> GetWorkersForEnterprise(string enterpriseId)
    {
        var workerIds = _relationRepository.GetWorkersByEnterpriseId(enterpriseId);
        return workerIds.Select(id => _workerRepository.GetWorkerById(id)).ToList();
    }

    public void CreateJobForEnterprise(string enterpriseId, string jobId, string jobName)
    {
        var enterprise = _enterpriseRepository.GetEnterpriseById(enterpriseId);
        if (enterprise != null)
        {
            var job = new Job(jobId, jobName);

            // Ajout du job au repository
            _jobRepository.AddJob(job);

            // Création de la relation entre l'entreprise et le job
            _enterpriseJobRelationRepository.AddRelation(enterpriseId, jobId);
        }
    }

    public List<IJob> GetJobsForEnterprise(string enterpriseId)
    {
        var jobIds = _enterpriseJobRelationRepository.GetJobsByEnterpriseId(enterpriseId);
        return jobIds.Select(id => _jobRepository.GetJobById(id)).ToList();
    }
}