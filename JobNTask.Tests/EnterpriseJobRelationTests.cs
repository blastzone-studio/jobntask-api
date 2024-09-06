using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;
using JobNTask.Lib.Service;

namespace JobNTask.Tests;

[TestClass]
public class EnterpriseJobRelationTests
{
    private IEnterpriseRepository _enterpriseRepository;
    private IJobRepository _jobRepository;
    private IEnterpriseJobRelationRepository _relationRepository;
    private EnterpriseJobService _enterpriseJobService;

    [TestInitialize]
    public void Setup()
    {
        _enterpriseRepository = new InMemoryEnterpriseRepository();
        _jobRepository = new InMemoryJobRepository();
        _relationRepository = new InMemoryEnterpriseJobRelationRepository();
        _enterpriseJobService = new EnterpriseJobService(_enterpriseRepository, _jobRepository, _relationRepository);
    }

    [TestMethod]
    public void CanAddAndRemoveJobFromEnterprise()
    {
        var enterprise = new Enterprise("1", "Tech Corp");
        var job = new Job("1", "Developer");

        _enterpriseRepository.AddEnterprise(enterprise);
        _enterpriseJobService.AddJobToEnterprise(enterprise.Id, job);

        var jobs = _enterpriseJobService.GetJobsForEnterprise(enterprise.Id);
        Assert.AreEqual(1, jobs.Count);
        Assert.AreEqual("Developer", jobs[0].Name);

        _enterpriseJobService.RemoveJobFromEnterprise(enterprise.Id, job.Id);
        jobs = _enterpriseJobService.GetJobsForEnterprise(enterprise.Id);
        Assert.AreEqual(0, jobs.Count);
    }
}