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
        AccTransaction GetById(int id);
        void Add(AccTransaction accTransaction);
        void Update(AccTransaction accTransaction);
        void Delete(int id);

    }
}
