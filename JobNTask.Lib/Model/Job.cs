namespace JobNTask.Lib.Model;

public class Job : IJob
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    public Job(string id, string name)
    {
        Id = id;
        Name = name;
    }
}