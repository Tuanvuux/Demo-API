﻿using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(APIDbContext context) : base(context)
        {
        }
    }
    
}
