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

        public Product Add(Product product)
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

            Product pro=_ProductRepository.Add(product);
            return pro;
        }

        public Product Delete(int id)
        {
        
            Product product = _ProductRepository.Remove(GetById(id));
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _ProductRepository.GetById(id); ;
        }

        public Product Update(Product product)
        {
            var errors = new List<string>();


            ProductType productType = _ProductTypeRepository.FindById(product.ProductTypeCd);
            if (productType == null)
            {
                errors.Add("ProductType does not exist");
            }

            

            var existingProduct = _ProductRepository.FindById(product.ProductCd);
            if (existingProduct == null)
            {
                errors.Add("Product not found");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingProduct.DateOffered = product.DateOffered;
            existingProduct.DateRetired = product.DateRetired;
            existingProduct.Name = product.Name;
            existingProduct.ProductTypeCd = product.ProductTypeCd;
            Product prod = _ProductRepository.Update(existingProduct);
            return prod;
        }
    }
}
