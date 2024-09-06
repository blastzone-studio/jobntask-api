using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public interface IWorkerRepository<T> where T : IWorkerEntity
{
    void AddWorker(T worker);
    void RemoveWorker(T worker);
    T GetWorkerById(string id);
    List<T> GetAllWorkers();
}