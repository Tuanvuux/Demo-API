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
    public class AccTransactionService : IAccTransactionService
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IAccTransactionRepository _AccTransactionRepository;
        private readonly ICustomerRepository _CustomerRepository;
        public readonly IBranchRepository _BranchRepository;
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IProductRepository _ProductRepository;

        public AccTransactionService(IAccTransactionRepository AccTransactionRepository, ICustomerRepository CustomerRepository,
            IBranchRepository BranchRepository, IEmployeeRepository EmployeeRepository, IProductRepository ProductRepository, IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
            _AccTransactionRepository = AccTransactionRepository;
            _BranchRepository = BranchRepository;
            _CustomerRepository = CustomerRepository;
            _EmployeeRepository = EmployeeRepository;
            _ProductRepository = ProductRepository;
        }

        public void Add(AccTransaction accTransaction)
        {
            Account ValidAccount = _AccountRepository.GetById(accTransaction.AccountId);
            Branch ValidBranch = _BranchRepository.GetById(accTransaction.ExcutionBranchId);
            Employee ValidEmployee = _EmployeeRepository.GetById(accTransaction.TellerEmpId);
            var errors = new List<string>();
            if (ValidAccount == null)
            {
                errors.Add("Account does not exist");
            }

            if (ValidBranch == null)
            {
                errors.Add("Branch does not exist");
            }
            if (ValidEmployee == null)
            {
                errors.Add("Employee does not exist");
            }

            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            _AccTransactionRepository.Add(accTransaction);

        }

        public void Delete(int id)
        {
            _AccTransactionRepository.Remove(GetById(id));
        }

        public IEnumerable<AccTransaction> GetAll()
        {
            return _AccTransactionRepository.GetAll();
        }

        public AccTransaction GetById(int id)
        {
            return _AccTransactionRepository.GetById(id); ;
        }

        public void Update(AccTransaction accTransaction)
        {

           throw new NotImplementedException();
        }
    }
}
