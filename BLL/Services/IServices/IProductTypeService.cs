using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IProductTypeService
    {
        IEnumerable<ProductType> GetAll();
        ProductType GetById(int id);
        ProductType Add(ProductType productType);
        ProductType Update(ProductType productType);
        ProductType Delete(int id);

    }
}
