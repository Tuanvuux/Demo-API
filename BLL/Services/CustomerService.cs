using BLL.Services.IServices;
using DAL.DTO;
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

        public void Add(Customer customer)
        {
            _CustomerRepository.Add(customer);
        }

        public void AddDTO(CustomerDTO customerDTO)
        {
            //_BusinessRepository.Add(customerDTO.business)
            Business business = new Business();
            business.Name = customerDTO.Name;
            business.StateId = customerDTO.StateId;
            business.IncorpDate = customerDTO.IncorpDate;
            _BusinessRepository.Add(business);
            Individual individual = new Individual();
            individual.BirthDay = customerDTO.BirthDay;
            individual.FirstName = customerDTO.FirstName;
            individual.LastName = customerDTO.LastName; 
            _IndividualRepository.Add(individual);
            Customer customer = new Customer();
            customer.Address = customerDTO.Address;
            customer.City = customerDTO.City;
            customer.CustTypeCd = customerDTO.CustTypeCd;
            customer.FedId = customerDTO.FedId;
            customer.PostalCode = customerDTO.PostalCode;
            customer.State = customerDTO.State;
            _CustomerRepository.Add(customer);
            
            //_IndividualRepository.Add(customerDTO.individual);


        }

        public void Delete(int id)
        {
            _CustomerRepository.Remove(GetById(id));
        }

        public IEnumerable<Customer> GetAll()
        {
            return _CustomerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _CustomerRepository.GetById(id); ;
        }

        public void Update(Customer customer)
        {

            var existingCustomer = _CustomerRepository.GetById(customer.CustId);
            if (existingCustomer != null)
            {
                existingCustomer.Address = customer.Address;
                existingCustomer.City = customer.City;
                existingCustomer.CustTypeCd = customer.CustTypeCd;
                existingCustomer.FedId = customer.FedId;
                existingCustomer.PostalCode = customer.PostalCode;
                existingCustomer.State = customer.State;
                _CustomerRepository.Update(customer);
            }
        }
    }
}
