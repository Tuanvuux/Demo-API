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

        public AccTransaction Add(AccTransaction accTransaction)
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
            if (accTransaction.Amount > ValidAccount.AvailBalance)
            {
                errors.Add("Account balance is insufficient");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            ValidAccount.AvailBalance = ValidAccount.AvailBalance - accTransaction.Amount;
            _AccountRepository.Update(ValidAccount);

            AccTransaction accTra= _AccTransactionRepository.Add(accTransaction);
            return accTra;

        }

        public AccTransaction Delete(int id)
        {
            
            AccTransaction accTransaction=_AccTransactionRepository.Remove(GetById(id));
            return accTransaction;
        }

        public IEnumerable<AccTransaction> GetAll()
        {
            return _AccTransactionRepository.GetAll();
        }

        

        public AccTransaction Update(AccTransaction accTransaction)
        {
            Account ValidAccount = _AccountRepository.GetById(accTransaction.AccountId);
            Branch ValidBranch = _BranchRepository.GetById(accTransaction.ExcutionBranchId);
            Employee ValidEmployee = _EmployeeRepository.GetById(accTransaction.TellerEmpId);
            AccTransaction existingAccTransaction = _AccTransactionRepository.GetById(accTransaction.Txn_Id);
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
            if (existingAccTransaction == null) {
                errors.Add("Acctransaction does not exist");
            }

            
            if (accTransaction.Amount > ValidAccount.AvailBalance+existingAccTransaction.Amount)
            {
                errors.Add("Account balance is insufficient");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }

            if (accTransaction.Amount > existingAccTransaction.Amount)
            {
                ValidAccount.AvailBalance = ValidAccount.AvailBalance - (accTransaction.Amount - existingAccTransaction.Amount);
            }
            else
            {
                ValidAccount.AvailBalance = ValidAccount.AvailBalance + existingAccTransaction.Amount - accTransaction.Amount;
                
            }
            
            existingAccTransaction.Amount = accTransaction.Amount;
            existingAccTransaction.Fund_Avail_Date = accTransaction.Fund_Avail_Date;
            existingAccTransaction.TxnDate = accTransaction.TxnDate;
            existingAccTransaction.TxnTypeCd = accTransaction.TxnTypeCd;
            existingAccTransaction.AccountId = accTransaction.AccountId;
            existingAccTransaction.ExcutionBranchId = accTransaction.ExcutionBranchId;
            existingAccTransaction.TellerEmpId = accTransaction.TellerEmpId;
            AccTransaction accTra= _AccTransactionRepository.Update(existingAccTransaction);
            _AccountRepository.Update(ValidAccount);
            return accTra;
        }

        public AccTransaction GetById(long id)
        {
            return _AccTransactionRepository.GetById(id);
        }
    }
}
