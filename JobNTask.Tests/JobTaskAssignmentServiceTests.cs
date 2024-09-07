using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;
using JobNTask.Lib.Service;
using System;
using JobNTask.Lib.Examples.Action;
using JobNTask.Lib.Examples.Target;

namespace JobNTask.Tests;

[TestClass]
public class JobTaskAssignmentServiceTests
{
    private IJobRepository? _jobRepository;
    private ITaskRepository? _taskRepository;
    private IJobTaskRelationRepository? _jobTaskRelationRepository;
    private JobTaskAssignmentService? _jobTaskAssignmentService;

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
        var task = new Task("1", "Design the Homepage", new CutAction(), 1, new Tree());

        _jobRepository!.AddJob(job);
        _taskRepository!.AddTask(task);

        _jobTaskAssignmentService!.AssignTaskToJob(job.Id, task.Id);

        var tasks = _jobTaskAssignmentService.GetTasksByJobId(job.Id);
        Assert.AreEqual(1, tasks.Count);
        Assert.AreEqual("Design the Homepage", tasks[0].Description);

        _jobTaskAssignmentService.RemoveTaskFromJob(job.Id, task.Id);
        tasks = _jobTaskAssignmentService.GetTasksByJobId(job.Id);
        Assert.AreEqual(0, tasks.Count);
    }


    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void CannotAssignTaskToMultipleJobs()
    {
        var job1 = new Job("1", "Build a Website");
        var job2 = new Job("2", "Develop a Mobile App");
        var task = new Task("1", "Design the Homepage", new CutAction(), 1, new Tree());

        _jobRepository!.AddJob(job1);
        _jobRepository!.AddJob(job2);
        _taskRepository!.AddTask(task);

        // Assign task to the first job
        _jobTaskAssignmentService!.AssignTaskToJob(job1.Id, task.Id);

        // Attempt to assign the same task to the second job should throw an exception
        _jobTaskAssignmentService!.AssignTaskToJob(job2.Id, task.Id);
    }
}
