using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IAccTransactionService
    {
        IEnumerable<AccTransaction> GetAll();
        AccTransaction GetById(long id);

        AccTransaction Add(AccTransaction accTransaction);
        AccTransaction Update(AccTransaction accTransaction);
        AccTransaction Delete(int id);

    }
}
