namespace JobNTask.Lib.Model;

public class EnterpriseJobRelation
{
    public string EnterpriseId { get; set; }
    public string JobId { get; set; }

    public EnterpriseJobRelation(string enterpriseId, string jobId)
    {
        EnterpriseId = enterpriseId;
        JobId = jobId;
    }
}