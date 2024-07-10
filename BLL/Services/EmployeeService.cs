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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IBranchRepository _BranchRepository;
        private readonly IDepartmentRepository _DepartmentRepository;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IBranchRepository BranchRepository, IDepartmentRepository DepartmentRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _BranchRepository = BranchRepository;
            _DepartmentRepository = DepartmentRepository;
        }

        public void Add(Employee employee)
        {
            Employee validEmployee = _EmployeeRepository.GetById(employee.SuperiorEmpId);
            Branch validBranch = _BranchRepository.GetById(employee.AssignedBranchId);
            Department validDepartment = _DepartmentRepository.GetById(employee.DeptId);
            var errors = new List<string>();



            if (validEmployee == null)
            {
                errors.Add("SuperiorEmpId Invalid");
            }
            if (validBranch == null) 
            {
                errors.Add("Branch does not exist");
            }
            if (validDepartment == null) 
            {
                errors.Add("Department does not exist");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            _EmployeeRepository.Add(employee);
        }

        public void Delete(int id)
        {
            _EmployeeRepository.Remove(GetById(id));
        }

        public IEnumerable<Employee> GetAll()
        {
            return _EmployeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _EmployeeRepository.GetById(id); ;
        }

        public void Update(Employee employee)
        {

            throw new NotImplementedException();
        }
    }
}
