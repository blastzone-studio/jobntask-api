namespace JobNTask.Lib.Model;

public interface ITask
{
    string Id { get; }
    string Description { get; }
    

    ITaskAction Action { get; }
    int CurrentQuantity { get; set; }
    int RequiredQuantity { get; }
    ITaskTarget Target { get; }

    bool IsCompleted() {
        return CurrentQuantity == RequiredQuantity;
    }

    void UpdateProgress(int quantity) {
        CurrentQuantity += quantity;
    }
}