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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _ProductTypeRepository;

        public ProductTypeService(IProductTypeRepository ProductTypeRepository)
        {
            _ProductTypeRepository = ProductTypeRepository;
        }

        public ProductType Add(ProductType productType)
        {
            ProductType prod=_ProductTypeRepository.Add(productType);
            return prod;
        }

        public ProductType Delete(int id)
        {
            ProductType prod = _ProductTypeRepository.Remove(GetById(id));
            return prod;
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _ProductTypeRepository.GetAll();
        }

        public ProductType GetById(int id)
        {
            return _ProductTypeRepository.GetById(id); ;
        }

        public ProductType Update(ProductType productType)
        {
            var errors = new List<string>();
            var existingProductType = _ProductTypeRepository.FindById(productType.ProductTypeCd);
            if (existingProductType != null)
            {
                errors.Add("ProductType is not exist");
                
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingProductType.Name = productType.Name;
            ProductType prod=_ProductTypeRepository.Update(existingProductType);
            return prod;
        }

       
    }
}
