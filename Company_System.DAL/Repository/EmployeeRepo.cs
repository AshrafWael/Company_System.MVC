using Company_System.Database;
using Company_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.DAL.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly Company_SystemContext _context;
        public EmployeeRepo(Company_SystemContext context)
        {
            _context = context;
        }
        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees.AsNoTracking();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(a=>a.Id==id);
        }

        public void Update(Employee employee)
        {
            _context.SaveChanges();
        }
    }
}
