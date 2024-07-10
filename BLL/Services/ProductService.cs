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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IProductTypeRepository _ProductTypeRepository;

        public ProductService(IProductRepository ProductRepository, IProductTypeRepository productTypeRepository)
        {
            _ProductRepository = ProductRepository;
            _ProductTypeRepository = productTypeRepository;
        }

        public void Add(Product product)
        {
            var errors = new List<string>();

            Product existingProduct = _ProductRepository.FindById(product.ProductCd);
            
            if (existingProduct != null)
            {
                errors.Add("Product is already exist");
            }

            ProductType productType = _ProductTypeRepository.FindById(product.ProductTypeCd);
            if (productType == null)
            {
                errors.Add("ProductType does not exist");
            }

            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }

            _ProductRepository.Add(product);
        }

        public void Delete(int id)
        {
            _ProductRepository.Remove(GetById(id));
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _ProductRepository.GetById(id); ;
        }

        public void Update(Product product)
        {

            throw new NotImplementedException();
        }
    }
}
