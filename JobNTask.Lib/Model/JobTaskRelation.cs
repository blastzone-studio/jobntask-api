namespace JobNTask.Lib.Model;

public class JobTaskRelation
{
    public string JobId { get; set; }
    public string TaskId { get; set; }

    public JobTaskRelation(string jobId, string taskId)
    {
        JobId = jobId;
        TaskId = taskId;
    }
}