using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private readonly APIDbContext context;
        public ProductTypeRepository(APIDbContext context) : base(context) {
           this.context = context;
        }

        public ProductType FindById( string id)
        {
            var productType = (from pt in context.ProductTypes
                              where pt.ProductTypeCd == id
                              select pt).FirstOrDefault();
            return productType;
        }

        
    }
}
