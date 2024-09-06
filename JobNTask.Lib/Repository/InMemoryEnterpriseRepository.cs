using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public class InMemoryEnterpriseRepository : IEnterpriseRepository
{
    private readonly Dictionary<string, IEnterprise> _enterprises = new Dictionary<string, IEnterprise>();

    public void AddEnterprise(IEnterprise enterprise)
    {
        _enterprises[enterprise.Id] = enterprise;
    }

    public void RemoveEnterprise(IEnterprise enterprise)
    {
        _enterprises.Remove(enterprise.Id);
    }

    public IEnterprise? GetEnterpriseById(string id)
    {
        _enterprises.TryGetValue(id, out var enterprise);
        return enterprise;
    }

    public List<IEnterprise> GetAllEnterprises()
    {
        return _enterprises.Values.ToList();
    }
}