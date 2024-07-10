using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BranchService : IBranchService
    {
        public readonly IBranchRepository _BranchRepository;
        public BranchService(IBranchRepository BranchRepository) {
            _BranchRepository = BranchRepository;
        }
        public void Add(Branch branch)
        {
            _BranchRepository.Add(branch);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> GetAll()
        {
            throw new NotImplementedException();
        }

        public Branch GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Branch branch)
        {
            throw new NotImplementedException();
        }
    }
}
