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

        public Employee Add(Employee employee)
        {
            Employee validEmployee = _EmployeeRepository.GetById(employee.SuperiorEmpId);
            Branch validBranch = _BranchRepository.GetById(employee.AssignedBranchId);
            Department validDepartment = _DepartmentRepository.GetById(employee.DeptId);
            var errors = new List<string>();

            IEnumerable<Employee> employees = _EmployeeRepository.GetAll();
            if (employees.Any()) {
                if (validEmployee == null)
                {
                    errors.Add("SuperiorEmpId Invalid");
                }

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
            Employee employ=_EmployeeRepository.Add(employee);
            return employ;
        }

        public Employee Delete(int id)
        {

            Employee employee = _EmployeeRepository.Remove(GetById(id));
            return employee;
            
        }

        public IEnumerable<Employee> GetAll()
        {
            return _EmployeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _EmployeeRepository.GetById(id); ;
        }

        public Employee Update(Employee employee)
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
            

            var existingEmployee = _EmployeeRepository.GetById(employee.EmpId);
            if (existingEmployee == null)
            {
                errors.Add("Employee not found");
            }
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }
            existingEmployee.EndDate = employee.EndDate;
            existingEmployee.StartDate = employee.StartDate;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Title = employee.Title;
            existingEmployee.AssignedBranchId = employee.AssignedBranchId;
            existingEmployee.DeptId = employee.DeptId;
            existingEmployee.SuperiorEmpId = employee.SuperiorEmpId;

            Employee employ = _EmployeeRepository.Update(existingEmployee);
            return employ;
        }
    }
}
