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
        
    }
}
