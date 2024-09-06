using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;
using JobNTask.Lib.Service;
using System;

[TestClass]
public class TaskAssignmentServiceTests
{
    private ITaskRepository _taskRepository;
    private IWorkerRepository<IWorkerEntity> _workerRepository;
    private ITaskWorkerRelationRepository _taskWorkerRelationRepository;
    private WorkerTaskAssignmentService _taskAssignmentService;

    [TestInitialize]
    public void Setup()
    {
        _taskRepository = new InMemoryTaskRepository();
        _workerRepository = new InMemoryWorkerRepository<IWorkerEntity>();
        _taskWorkerRelationRepository = new InMemoryTaskWorkerRelationRepository();
        _taskAssignmentService = new WorkerTaskAssignmentService(_taskWorkerRelationRepository, _taskRepository, _workerRepository);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void CannotAssignTaskToMultipleWorkers()
    {
        var worker1 = new WorkerEntity("1");
        var worker2 = new WorkerEntity("2");
        var task = new Task("1", "Fix the Bug");

        _workerRepository.AddWorker(worker1);
        _workerRepository.AddWorker(worker2);
        _taskRepository.AddTask(task);

        // Assign task to the first worker
        _taskAssignmentService.AssignTaskToWorker(task.Id, worker1.Id);

        // Attempt to assign the same task to the second worker should throw an exception
        _taskAssignmentService.AssignTaskToWorker(task.Id, worker2.Id);
    }


}