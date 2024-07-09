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
        Branch GetById(int id);
        void Add(Branch branch);
        void Update(Branch branch);
        void Delete(int id);
    }
}
