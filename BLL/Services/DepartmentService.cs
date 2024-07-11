using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _DepartmentRepository;

        public DepartmentService(IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        public Department Add(Department department)
        {
            Department dep=_DepartmentRepository.Add(department);
            return dep;
        }

        public Department Delete(int id)
        {
         
            Department department = _DepartmentRepository.Remove(GetById(id));
            return department;
        }

        public IEnumerable<Department> GetAll()
        {
            return _DepartmentRepository.GetAll();
        }

        public Department GetById(int id)
        {
            return _DepartmentRepository.GetById(id); ;
        }

        public Department Update(Department department)
        {
            var errors = new List<string>();
            var existingDepartment = _DepartmentRepository.GetById(department.DeptId);
            if (existingDepartment == null)
            {
                errors.Add("Department is not exits");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingDepartment.Name = department.Name;

            Department dep = _DepartmentRepository.Update(existingDepartment);
            return dep;
        }
    }
}
