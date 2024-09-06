namespace JobNTask.Lib.Model;

public class JobWorkerRelation
{
    public string JobId { get; set; }
    public string WorkerId { get; set; }

    public JobWorkerRelation(string jobId, string workerId)
    {
        JobId = jobId;
        WorkerId = workerId;
    }
}