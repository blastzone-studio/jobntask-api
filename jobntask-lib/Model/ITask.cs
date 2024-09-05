namespace jobntask_lib.Model;

public interface ITask
{
    string Id { get; }
    string Description { get; }
    bool IsCompleted { get; }

    void MarkAsCompleted();
    void MarkAsIncomplete();
}