using JobNTask.Lib.Model;
using JobNTask.Lib.Repository;

namespace JobNTask.Lib.Service;

public class WorkerTaskAssignmentService
{
    private readonly ITaskWorkerRelationRepository _taskWorkerRelationRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IWorkerRepository<IWorkerEntity> _workerRepository;

    public WorkerTaskAssignmentService(ITaskWorkerRelationRepository taskWorkerRelationRepository, 
                                 ITaskRepository taskRepository,
                                 IWorkerRepository<IWorkerEntity> workerRepository)
    {
        _taskWorkerRelationRepository = taskWorkerRelationRepository;
        _taskRepository = taskRepository;
        _workerRepository = workerRepository;
    }

    public void AssignTaskToWorker(string taskId, string workerId)
    {
        var task = _taskRepository.GetTaskById(taskId);
        var worker = _workerRepository.GetWorkerById(workerId);

        if (task != null && worker != null)
        {
            // Vérifier si la tâche est déjà assignée à un autre worker
            var currentWorkerId = _taskWorkerRelationRepository.GetWorkerIdByTaskId(taskId);
            if (currentWorkerId != null)
            {
                throw new InvalidOperationException($"La tâche {taskId} est déjà assignée au worker {currentWorkerId}.");
            }

            _taskWorkerRelationRepository.AddRelation(taskId, workerId);
        }
    }

    public void RemoveTaskFromWorker(string taskId)
    {
        var workerId = _taskWorkerRelationRepository.GetWorkerIdByTaskId(taskId);
        if (workerId != null)
        {
            _taskWorkerRelationRepository.RemoveRelation(taskId, workerId);
        }
    }

    public List<ITask> GetTasksForWorker(string workerId)
    {
        var taskIds = _taskWorkerRelationRepository.GetTasksByWorkerId(workerId);
        return taskIds.Select(id => _taskRepository.GetTaskById(id)).OfType<ITask>().ToList();
    }

    public string? GetWorkerIdByTaskId(string taskId)
    {
        return _taskWorkerRelationRepository.GetWorkerIdByTaskId(taskId);
    }

    public IWorkerEntity? GetWorkerByTaskId(string taskId)
    {
        string? workerId = _taskWorkerRelationRepository.GetWorkerIdByTaskId(taskId);
        if (workerId != null) {
            return _workerRepository.GetWorkerById(workerId);
        } 
        return null;
    }
}
