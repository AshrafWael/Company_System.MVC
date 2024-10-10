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
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo _repo;

        public DepartmentManager(IDepartmentRepo repo)
        {
            _repo = repo;
        }
        public void Add(DepartmentVm departmentVM)
        {
            var Department = new Department()
            {
                Name= departmentVM.Name,
            };

            _repo.Add(Department);
        }

        public void Delete(int id)
        {
            var Department=_repo.GetById(id);
            _repo.Delete(Department);
        }

        public List<DepartmentVm> GetAll()
        {
           var Departments = _repo.GetAll().Select(a => new DepartmentVm
           {
               Id=a.Id,
               Name=a.Name,
           }).ToList();

            return Departments;
        }

        public DepartmentVm GetById(int id)
        {
            var Department = _repo.GetById(id);
            var DepartmentReadVM = new DepartmentVm
            {
                Id = Department.Id,
                Name = Department.Name,
            };

            return DepartmentReadVM;
        }

        public void Update(DepartmentVm DepartmentVM)
        {
            var Department = _repo.GetById(DepartmentVM.Id);
            Department.Name=DepartmentVM.Name;

            _repo.Update(Department);
        }
    }
}
