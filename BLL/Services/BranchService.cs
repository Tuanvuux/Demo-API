using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories;
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
        public Branch Add(Branch branch)
        {
            Branch br= _BranchRepository.Add(branch);
            return br;
        }

        public Branch Delete(int id)
        {
            Branch br = _BranchRepository.Remove(GetById(id));
            return br;
        }

        public IEnumerable<Branch> GetAll()
        {
            return _BranchRepository.GetAll();
        }

        public Branch GetById(int id)
        {
            return _BranchRepository.GetById(id);
        }

        public Branch Update(Branch branch)
        {
            var errors = new List<string>();
            var existingBranch = _BranchRepository.GetById(branch.BranchId);
            if (existingBranch == null)
            {
                errors.Add("Branch does not exist");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingBranch.Address = branch.Address;
            existingBranch.City = branch.City;
            existingBranch.State = branch.State;
            existingBranch.ZipCode = branch.ZipCode;
            existingBranch.Name = branch.Name;

            Branch br =  _BranchRepository.Update(existingBranch);
            return br;
        }
        public IEnumerable<Branch> FindByName(string name)
        {
            return _BranchRepository.FindByName(name);
        }
    }
}
