using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IBranchService
    {
        IEnumerable<Branch> GetAll();
        IEnumerable<Branch> FindByName(string name);
        Branch GetById(int id);
        Branch Add(Branch branch);
        Branch Update(Branch branch);
        Branch Delete(int id);
    }
}
