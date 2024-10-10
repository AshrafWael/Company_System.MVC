using Company_System.DAL.Repository;
using Company_System.Models;
using Company_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo _repo;

        public EmployeeManager(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public void Add(EmployeeAddVM employeeVM)
        {
            var employee = new Employee()
            {
                Name= employeeVM.Name,
                Age= employeeVM.Age,
                Salary= employeeVM.Salary,
                DepartmentId= employeeVM.DepartmentId,
                ImgUrl = employeeVM.ImgUrl
            };

            _repo.Add(employee);
        }

        public void Delete(int id)
        {
            var employee=_repo.GetById(id);
            _repo.Delete(employee);
        }

        public List<EmployeeReadVM> GetAll()
        {
           var employees = _repo.GetAll().Select(a => new EmployeeReadVM
           {
               Age=a.Age,
               Name=a.Name,
               DepartmentName=a.Department.Name,
               ImgUrl=a.ImgUrl

           }).ToList();

            return employees;
        }

        public EmployeeReadVM GetById(int id)
        {
            var employee = _repo.GetById(id);
            var employeeReadVM = new EmployeeReadVM
            {
                Name = employee.Name,
                ImgUrl = employee.ImgUrl,
                Age = employee.Age,
                DepartmentName = employee.Department.Name,
            };

            return employeeReadVM;
        }

        public void Update(EmployeeEditVM employeeVM)
        {
            var employee = _repo.GetById(employeeVM.Id);
            employee.Age=employeeVM.Age;
            employee.Name=employeeVM.Name;

            _repo.Update(employee);
        }
    }
}
