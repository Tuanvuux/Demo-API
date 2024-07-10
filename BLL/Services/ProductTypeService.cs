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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _ProductTypeRepository;

        public ProductTypeService(IProductTypeRepository ProductTypeRepository)
        {
            _ProductTypeRepository = ProductTypeRepository;
        }

        public void Add(ProductType productType)
        {
            _ProductTypeRepository.Add(productType);
        }

        public void Delete(int id)
        {
            _ProductTypeRepository.Remove(GetById(id));
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _ProductTypeRepository.GetAll();
        }

        public ProductType GetById(int id)
        {
            return _ProductTypeRepository.GetById(id); ;
        }

        public void Update(ProductType productType)
        {

            this._ProductTypeRepository.Update(productType);
        }
    }
}
