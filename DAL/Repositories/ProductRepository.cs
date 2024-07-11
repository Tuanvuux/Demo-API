﻿using DAL.Context;
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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly APIDbContext context;
        public ProductRepository(APIDbContext context) : base(context) {
           this.context = context;
        }

        public Product FindById(string id)
        {
            return (from p in context.Products
                                  where p.ProductCd == id
                                  select p).FirstOrDefault();
        }
    }
}
