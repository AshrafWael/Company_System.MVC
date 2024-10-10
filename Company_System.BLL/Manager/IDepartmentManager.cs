using Company_System.Models;
using Company_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.Manager
{
    public interface IDepartmentManager
    {
        List<DepartmentVm> GetAll();
        DepartmentVm GetById(int id);
        void Add(DepartmentVm employeeVM);
        void Update(DepartmentVm employeeVM);
        void Delete(int id);
    }
}
