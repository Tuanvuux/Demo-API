using DAL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<CustomerDTORespond> GetCustomerByName(string name);
        List<CustomerAccountDTO> GetCustomerAccountsAndTransactions(int Id);
        List<CustomerDTORespond> GetAllCustomerDTO();
    }
}
