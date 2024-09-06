using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;
using JobNTask.Lib.Service;


[TestClass]
public class JobTaskAssignmentServiceTests
{
    private IJobRepository _jobRepository;
    private ITaskRepository _taskRepository;
    private IJobTaskRelationRepository _jobTaskRelationRepository;
    private JobTaskAssignmentService _jobTaskAssignmentService;

    [TestInitialize]
    public void Setup()
    {
        _jobRepository = new InMemoryJobRepository();
        _taskRepository = new InMemoryTaskRepository();
        _jobTaskRelationRepository = new InMemoryJobTaskRelationRepository();
        _jobTaskAssignmentService = new JobTaskAssignmentService(_jobTaskRelationRepository, _taskRepository, _jobRepository);
    }

    [TestMethod]
    public void CanAssignAndRemoveTaskFromJob()
    {
        var job = new Job("1", "Build a Website");
        var task = new Task("1", "Design the Homepage");

        _jobRepository.AddJob(job);
        _taskRepository.AddTask(task);

        _jobTaskAssignmentService.AssignTaskToJob(job.Id, task.Id);

        var tasks = _jobTaskAssignmentService.GetTasksForJob(job.Id);
        Assert.AreEqual(1, tasks.Count);
        Assert.AreEqual("Design the Homepage", tasks[0].Description);

        _jobTaskAssignmentService.RemoveTaskFromJob(job.Id, task.Id);
        tasks = _jobTaskAssignmentService.GetTasksForJob(job.Id);
        Assert.AreEqual(0, tasks.Count);
    }
}
