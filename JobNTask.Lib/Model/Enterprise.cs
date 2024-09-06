namespace JobNTask.Lib.Model;

public class Enterprise : IEnterprise
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    public Enterprise(string id, string name)
    {
        Id = id;
        Name = name;
    }
}