using BLL.Services.IServices;
using DAL.Entities;
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

        public void Add(Department department)
        {
            _DepartmentRepository.Add(department);
        }

        public void Delete(int id)
        {
            _DepartmentRepository.Remove(GetById(id));
        }

        public IEnumerable<Department> GetAll()
        {
            return _DepartmentRepository.GetAll();
        }

        public Department GetById(int id)
        {
            return _DepartmentRepository.GetById(id); ;
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
