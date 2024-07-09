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
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {
        public BusinessRepository(APIDbContext context) : base(context)
        {
        }
    }
}
