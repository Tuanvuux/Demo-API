using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public User Add(User user)
        {
            var errors = new List<string>();
            var exitsUser = _UserRepository.FindByEmail(user.UserEmail);
            if (exitsUser != null)
            {
                errors.Add("Email is exits");
            }

            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            User user1 = _UserRepository.Add(user);
            return user1;
        }

        public User FindByEmail(string UserEmail)
        {
            return _UserRepository.FindByEmail(UserEmail);
        }

        public User GetById(int id)
        {
            return _UserRepository.GetById(id); ;
        }

        public User CheckUser(User user)
        {
            var errors = new List<string>();
            var exitsUser = _UserRepository.FindByEmail(user.UserEmail);
            if (exitsUser == null)
            {
                errors.Add("User not exits");
            }
            else
            {
                if (user.Password != exitsUser.Password)
                {
                    errors.Add("Password not true");
                }
                


            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            return exitsUser;
        }
    }
}