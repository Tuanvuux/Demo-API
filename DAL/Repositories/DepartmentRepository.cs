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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly APIDbContext context;
        public DepartmentRepository(APIDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Department> FindByName(string name)
        {
            return (from p in context.Departments
                    where p.Name.Contains(name)
                    select p);
        }
    }
}
