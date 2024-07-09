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
    public class IndividualRepository:Repository<Individual>, IIndividualRepository
    {
        public IndividualRepository(APIDbContext context) : base(context) { }
    }
}
