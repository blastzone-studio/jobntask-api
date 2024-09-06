namespace JobNTask.Lib.Model;

public class TaskWorkerRelation
{
    public string TaskId { get; set; }
    public string WorkerId { get; set; }

    public TaskWorkerRelation(string taskId, string workerId)
    {
        TaskId = taskId;
        WorkerId = workerId;
    }
}