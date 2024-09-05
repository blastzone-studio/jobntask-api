namespace jobntask_lib.Model;

public class Task : ITask
{
    public string Id { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }

    public Task(string id, string description)
    {
        Id = id;
        Description = description;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public void MarkAsIncomplete()
    {
        IsCompleted = false;
    }
}