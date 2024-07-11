﻿using BLL.Services.IServices;
using DAL.DTO;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBusinessRepository _BusinessRepository;
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IIndividualRepository _IndividualRepository;

        public CustomerService(IBusinessRepository BusinessRepository, ICustomerRepository CustomerRepository, IIndividualRepository IndividualRepository)
        {
            _BusinessRepository = BusinessRepository;
            _CustomerRepository = CustomerRepository;
            _IndividualRepository = IndividualRepository;
        }

        public Customer Add(Customer customer)
        {
            Customer Cus=_CustomerRepository.Add(customer);
            return Cus;
        }

        public CustomerDTO AddDTO(CustomerDTO customerDTO)
        {
            var errors = new List<string>();

            
            if (customerDTO.CustTypeCd != "B" && customerDTO.CustTypeCd !="I")
            {
                errors.Add("CUST_TYPE_CD different from B or I");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            Customer customer = new Customer();
            customer.Address = customerDTO.Address;
            customer.City = customerDTO.City;
            customer.CustTypeCd = customerDTO.CustTypeCd;
            customer.FedId = customerDTO.FedId;
            customer.PostalCode = customerDTO.PostalCode;
            customer.State = customerDTO.State;
            Customer cus=_CustomerRepository.Add(customer);
            //_BusinessRepository.Add(customerDTO.business)
            Business business = new Business();
            business.CustId = cus.CustId;
            business.Name = customerDTO.Name;
            business.StateId = customerDTO.StateId;
            business.IncorpDate = customerDTO.IncorpDate;
            _BusinessRepository.Add(business);
            Individual individual = new Individual();
            individual.Cust_Id=cus.CustId;
            individual.BirthDay = customerDTO.BirthDay;
            individual.FirstName = customerDTO.FirstName;
            individual.LastName = customerDTO.LastName; 
            _IndividualRepository.Add(individual);
            customerDTO.CustId=cus.CustId;
            
            return customerDTO;
            
            //_IndividualRepository.Add(customerDTO.individual);


        }

        public Customer Delete(int id)
        {
            Customer customer= _CustomerRepository.Remove(GetById(id));
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _CustomerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _CustomerRepository.GetById(id); ;
        }

        public Customer Update(Customer customer)
        {
            var errors = new List<string>();
            if (customer.CustTypeCd != "B" || customer.CustTypeCd != "I")
            {
                errors.Add("CUST_TYPE_CD different from B or I");
            }
            

            var existingCustomer = _CustomerRepository.GetById(customer.CustId);
            if (existingCustomer == null)
            {
                errors.Add("Customer is not found");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingCustomer.Address = customer.Address;
            existingCustomer.City = customer.City;
            existingCustomer.CustTypeCd = customer.CustTypeCd;
            existingCustomer.FedId = customer.FedId;
            existingCustomer.PostalCode = customer.PostalCode;
            existingCustomer.State = customer.State;
            Customer Cus = _CustomerRepository.Update(existingCustomer);
            return Cus;
            
        }

        
    }
}
