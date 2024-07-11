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
        Business Add(Business business);
        Business Update(Business business);
        Business Delete(int id);

    }
}
