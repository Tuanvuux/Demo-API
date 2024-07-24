using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IBranchRepository : IRepository<Branch>
    {
        IEnumerable<Branch> FindByName(string name);
    }
}
