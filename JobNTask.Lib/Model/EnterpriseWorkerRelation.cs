namespace JobNTask.Lib.Model;

public class EnterpriseWorkerRelation
{
    public string EnterpriseId { get; set; }
    public string WorkerId { get; set; }

    public EnterpriseWorkerRelation(string enterpriseId, string workerId)
    {
        EnterpriseId = enterpriseId;
        WorkerId = workerId;
    }
}