using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _BusinessRepository;

        public BusinessService(IBusinessRepository BusinessRepository)
        {
            _BusinessRepository = BusinessRepository;
        }

        public void Add(Business business)
        {
            _BusinessRepository.Add(business);
        }

        public void Delete(int id)
        {
            _BusinessRepository.Remove(GetById(id));
        }

        public IEnumerable<Business> GetAll()
        {
            return _BusinessRepository.GetAll();
        }

        public Business GetById(int id)
        {
            return _BusinessRepository.GetById(id); ;
        }

        public void Update(Business business)
        {

            var existingBusiness = _BusinessRepository.GetById(business.CustId);
            if (existingBusiness != null)
            {
                existingBusiness.IncorpDate=business.IncorpDate;
                existingBusiness.Name=business.Name;
                existingBusiness.StateId=business.StateId;
                _BusinessRepository.Update(business);
            }
        }
    }
}
