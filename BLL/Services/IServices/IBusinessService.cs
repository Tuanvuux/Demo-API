using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IBusinessService
    {
        IEnumerable<Business> GetAll();
        Business GetById(int id);
        void Add(Business business);
        void Update(Business business);
        void Delete(int id);

    }
}
