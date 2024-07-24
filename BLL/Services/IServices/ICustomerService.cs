﻿using DAL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        Customer Delete(int id);
        CustomerDTO AddDTO(CustomerDTO customerDTO);

        List<CustomerDTORespond> GetCustomerByName(String name);
        List<CustomerDTORespond> GetAllCustomerDTO();
        List<CustomerAccountDTO> GetCustomerAccountsAndTransactions(int customerId);
    }
}
