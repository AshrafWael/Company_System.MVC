using Company_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.Manager
{
    public interface IEmployeeManager
    {
        List<EmployeeReadVM> GetAll();
        EmployeeReadVM GetById(int id);
        void Add(EmployeeAddVM employeeVM);
        void Update(EmployeeEditVM employeeVM);
        void Delete(int id);
    }
}
