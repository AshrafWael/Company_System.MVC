using Company_System.Models;

namespace Company_System.ViewModels
{
    public class EmployeeWithDepartmentVM
    {
        public EmployeeReadVM Employee { get; set; }
        public List<DepartmentVm> Departments { get; set; }
    }
}
