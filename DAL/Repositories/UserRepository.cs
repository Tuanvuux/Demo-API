using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly APIDbContext context;
        public UserRepository(APIDbContext context) : base(context)
        {
            this.context = context;
        }

        public User FindByEmail(string UserEmail)
        {
            var user = (from p in context.Users
                       where p.UserEmail == UserEmail
                       select p).FirstOrDefault();
            return user;
        }
    }
}
