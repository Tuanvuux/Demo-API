using DAL.Context;
using DAL.DTO;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly APIDbContext context;
        public CustomerRepository(APIDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<CustomerDTORespond> GetCustomerByName(string name)
        {
            var query = from customer in _context.Customers
                        join business in _context.Businesses on customer.CustId equals business.CustId into businessGroup
                        from business in businessGroup.DefaultIfEmpty()
                        join individual in _context.Individuals on customer.CustId equals individual.Cust_Id into individualGroup
                        from individual in individualGroup.DefaultIfEmpty()
                        where business.Name.Contains(name) || individual.FirstName.Contains(name) || individual.LastName.Contains(name)
                        select new CustomerDTORespond
                        {
                            CustId = customer.CustId,
                            FullName = customer.CustTypeCd == "B" ? business.Name : individual.FirstName + " " + individual.LastName,
                            BirthDay = customer.CustTypeCd == "I" ? individual.BirthDay : null,
                            IncorpDay = customer.CustTypeCd == "B" ? business.IncorpDate : null,
                            Address = customer.Address,
                            City = customer.City,
                            CustomerType = customer.CustTypeCd == "B" ? "BUSINESS" : "INDIVIDUAL"
                        };

            List<CustomerDTORespond> results =  query.ToList();
             return  results;
           
           
        }

        public List<CustomerAccountDTO> GetCustomerAccountsAndTransactions(int customerId)
        {
            var query = from customer in context.Customers
                        where customer.CustId == customerId
                        join account in context.Accounts on customer.CustId equals account.CustId into customerAccounts
                        from ca in customerAccounts.DefaultIfEmpty()
                        join transaction in context.AccTransactions on ca.Account_Id equals transaction.AccountId into accountTransactions
                        from at in accountTransactions.DefaultIfEmpty()
                        join branch in context.Branches on at.ExcutionBranchId equals branch.BranchId into branches
                        from b in branches.DefaultIfEmpty()
                        join employee in context.Employees on at.TellerEmpId equals employee.EmpId into employees
                        from e in employees.DefaultIfEmpty()
                        join product in context.Products on ca.ProductCd equals product.ProductCd into products
                        from p in products.DefaultIfEmpty()
                        join productType in context.ProductTypes on p.ProductTypeCd equals productType.ProductTypeCd into productTypes
                        from pt in productTypes.DefaultIfEmpty()
                        select new
                        {
                            CustomerId = customer.CustId,
                            TotalBalance = ca.AvailBalance != null ? ca.AvailBalance : 0,
                            Account = new AccountDTO
                            {
                                Account = ca,
                                BranchName = b.Name,
                                EmployeeName = $"{e.FirstName} {e.LastName}",
                                ProductName = p.Name,
                                ProductTypeName = pt.Name,
                                AccountTransaction = context.AccTransactions.Select(at => new AccountTransactionDTO
                                {
                                    accTransaction = at,
                                    BranchName = b.Name,
                                    EmployeeName = $"{e.FirstName} {e.LastName}"
                                }).ToList()
                            }
                        };



            var groupedByCustomer = query.ToList()
                                         .GroupBy(q => q.CustomerId)
                                         .Select(group => new CustomerAccountDTO
                                         {
                                             CustomerId = group.Key,
                                             TotalBalance = group.Sum(g => g.TotalBalance),
                                             Accounts = group.Select(g => g.Account).ToList()
                                         })
                                         .ToList();

            return groupedByCustomer;
        }



    }
}
