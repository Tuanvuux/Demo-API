using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly APIDbContext context;
        public BranchRepository(APIDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Branch> FindByName(string name)
        {
            return (from p in context.Branches
                    where p.Name.Contains(name)
                    select p);
        }
    }
    
}
