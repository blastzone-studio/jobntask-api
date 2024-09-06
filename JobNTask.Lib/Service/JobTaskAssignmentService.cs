using JobNTask.Lib.Repository;
using JobNTask.Lib.Model;

namespace JobNTask.Lib.Service;

public class JobTaskAssignmentService
{
    private readonly IJobTaskRelationRepository _jobTaskRelationRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IJobRepository _jobRepository;

    public JobTaskAssignmentService(IJobTaskRelationRepository jobTaskRelationRepository, 
                                    ITaskRepository taskRepository,
                                    IJobRepository jobRepository)
    {
        _jobTaskRelationRepository = jobTaskRelationRepository;
        _taskRepository = taskRepository;
        _jobRepository = jobRepository;
    }

    
    public void AssignTaskToJob(string jobId, string taskId)
    {
        var job = _jobRepository.GetJobById(jobId);
        var task = _taskRepository.GetTaskById(taskId);

        if (job != null && task != null)
        {
            var currentJobId = _jobTaskRelationRepository.GetJobByTaskId(taskId);
            if (currentJobId != null)
            {
                throw new InvalidOperationException($"La tâche {taskId} est déjà assignée au job {currentJobId}.");
            }

            _jobTaskRelationRepository.AddRelation(jobId, taskId);
        }
    }

    public void RemoveTaskFromJob(string jobId, string taskId)
    {
        _jobTaskRelationRepository.RemoveRelation(jobId, taskId);
    }

    public List<ITask> GetTasksForJob(string jobId)
    {
        var taskIds = _jobTaskRelationRepository.GetTasksByJobId(jobId);
        return taskIds.Select(id => _taskRepository.GetTaskById(id)).ToList();
    }

    public string GetJobForTask(string taskId)
    {
        return _jobTaskRelationRepository.GetJobByTaskId(taskId);
    }
}
