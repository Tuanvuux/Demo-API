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

        public Account Add(Account account)
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
            Account acc=_AccountRepository.Add(account);
            return acc;
        }

        public Account Delete(int id)
        {

            Account Account =_AccountRepository.Remove(GetById(id));
            return Account;
        }

        public IEnumerable<Account> GetAll()
        {
            return _AccountRepository.GetAll();
        }

        public Account GetById(int id)
        {
            return _AccountRepository.GetById(id); ;
        }

        public Account Update(Account account)
        {
            
            Branch ValidBranch = _BranchRepository.GetById(account.OpenBranchId);
            Customer ValidCustomer = _CustomerRepository.GetById(account.CustId);
            Employee ValidEmployee = _EmployeeRepository.GetById(account.OpenEmpId);
            var errors = new List<string>();
            
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
        
            var existingAccount = _AccountRepository.GetById(account.Account_Id);
            if (existingAccount == null)
            {
                errors.Add("Account Invalidate");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingAccount.AvailBalance = account.AvailBalance;
            existingAccount.CloseDate = account.CloseDate;
            existingAccount.LastActivityDay = account.LastActivityDay;
            existingAccount.OpenDate = account.OpenDate;
            existingAccount.PendingBalance = account.PendingBalance;
            existingAccount.Status = account.Status;
            existingAccount.CustId = account.CustId;
            existingAccount.OpenBranchId = account.OpenBranchId;
            existingAccount.OpenEmpId = account.OpenEmpId;
            existingAccount.ProductCd = account.ProductCd;
            Account Account =_AccountRepository.Update(existingAccount);
            return Account;
            
        }
    }
}
