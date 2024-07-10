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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly ICustomerRepository _CustomerRepository;
        public readonly IBranchRepository _BranchRepository;
        private readonly IEmployeeRepository _EmployeeRepository;
        public AccountService(IEmployeeRepository EmployeeRepository, IAccountRepository AccountRepository, ICustomerRepository CustomerRepository, IBranchRepository BranchRepository)
        {
            _AccountRepository = AccountRepository;
            _CustomerRepository = CustomerRepository;
            _BranchRepository = BranchRepository;
            _EmployeeRepository = EmployeeRepository;
        }

        public void Add(Account account)
        {
            Account ValidAccount = _AccountRepository.GetById(account.Account_Id);
            Branch ValidBranch = _BranchRepository.GetById(account.OpenBranchId);
            Customer ValidCustomer = _CustomerRepository.GetById(account.CustId);
            Employee ValidEmployee = _EmployeeRepository.GetById(account.OpenEmpId);
            var errors = new List<string>();
            if (ValidAccount != null)
            {
                errors.Add("Account is exist");
            }
            if (ValidBranch == null)
            {
                errors.Add("Branch does not exist");
            }
            if (ValidCustomer == null)
            {
                errors.Add("Customer does not exist");
            }
            if (_EmployeeRepository == null)
            {
                errors.Add("Employee does not exist");
            }

            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            _AccountRepository.Add(account);
        }

        public void Delete(int id)
        {
            _AccountRepository.Remove(GetById(id));
        }

        public IEnumerable<Account> GetAll()
        {
            return _AccountRepository.GetAll();
        }

        public Account GetById(int id)
        {
            return _AccountRepository.GetById(id); ;
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
