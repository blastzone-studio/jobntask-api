using JobNTask.Lib.Model;

namespace JobNTask.Lib.Repository;

public interface IEnterpriseRepository
{
    void AddEnterprise(IEnterprise enterprise);
    void RemoveEnterprise(IEnterprise enterprise);
    IEnterprise? GetEnterpriseById(string id);
    List<IEnterprise> GetAllEnterprises();
}