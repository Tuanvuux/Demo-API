using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll();
        Account GetById(int id);
        Account Add(Account account);
        Account Update(Account account);
        Account Delete(int id);

    }
}
