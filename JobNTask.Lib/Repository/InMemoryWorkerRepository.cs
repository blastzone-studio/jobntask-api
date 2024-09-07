using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryWorkerRepository<T> : IWorkerRepository<T> where T : IWorkerEntity
{
    private readonly Dictionary<string, T> _workers = new Dictionary<string, T>();

    public void AddWorker(T worker)
    {
        if (!_workers.ContainsKey(worker.Id))
        {
            _workers[worker.Id] = worker;
        }
    }

    public void RemoveWorker(T worker)
    {
        if (_workers.ContainsKey(worker.Id))
        {
            _workers.Remove(worker.Id);
        }
    }

    public T? GetWorkerById(string id)
    {
        _workers.TryGetValue(id, out var worker);
        return worker;
    }

    public List<T> GetAllWorkers()
    {
        return _workers.Values.ToList();
    }
}