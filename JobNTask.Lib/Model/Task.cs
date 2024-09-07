namespace JobNTask.Lib.Model;

public class Task : ITask
{
    public string Id { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }

    public ITaskAction Action { get; private set; }

    public int CurrentQuantity { get; set; } = 0;

    public int RequiredQuantity { get; private set; }

    public ITaskTarget Target { get; private set; }

    public Task(string id, string description, ITaskAction action, int requiredQuantity, ITaskTarget target)
    {
        Id = id;
        Description = description;
        Action = action;
        RequiredQuantity = requiredQuantity;
        Target = target;
    }
}