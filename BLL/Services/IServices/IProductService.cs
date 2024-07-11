using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);

    }
}
