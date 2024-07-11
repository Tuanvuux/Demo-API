using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);

    }
}
