namespace JobNTask.Lib.Model;

public interface ITask
{
    string Id { get; }
    string Description { get; }
    bool IsCompleted { get; }

    void MarkAsCompleted();
    void MarkAsIncomplete();
}