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

        public Business Add(Business business)
        {
            Business busi=_BusinessRepository.Add(business);
            return busi;

        }

        public Business Delete(int id)
        {
            Business busi = _BusinessRepository.Remove(GetById(id));
            return busi;
        }

        public IEnumerable<Business> GetAll()
        {
            return _BusinessRepository.GetAll();
        }

        public Business GetById(int id)
        {
            return _BusinessRepository.GetById(id); ;
        }

        public Business Update(Business business)
        {
            var errors = new List<string>();
            var existingBusiness = _BusinessRepository.GetById(business.CustId);
            if (existingBusiness != null)
            {
                errors.Add("Busniess is not exist");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingBusiness.IncorpDate = business.IncorpDate;
            existingBusiness.Name = business.Name;
            existingBusiness.StateId = business.StateId;
            Business busi=_BusinessRepository.Update(business);
            return busi;
        }
    }
}
