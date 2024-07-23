using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        IEnumerable<Department> FindByName(string name);
        Department GetById(int id);
        Department Add(Department department);
        Department Update(Department department);
        Department Delete(int id);

    }
}
