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
    public class AccTransactionRepository : Repository<AccTransaction>, IAccTransactionRepository
    {
        private readonly APIDbContext context;
        public AccTransactionRepository(APIDbContext context) : base(context) { 
            this.context = context;
        }
        public AccTransaction GetById(long id)
        {
            var accTransaction = (from pt in context.AccTransactions
                               where pt.Txn_Id == id
                               select pt).FirstOrDefault();
            return accTransaction;
        }

        
    }
}
