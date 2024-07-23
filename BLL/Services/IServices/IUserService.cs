using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IUserService
    {

        User GetById(int id);
        User Add(User user);

        User FindByEmail(string UserEmail);
        User CheckUser(User user);
    }
}
