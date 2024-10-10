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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly Company_SystemContext _context;
        public DepartmentRepo(Company_SystemContext context)
        {
            _context = context;
        }
        public void Add(Department Department)
        {
            _context.Add(Department);
            _context.SaveChanges();
        }

        public void Delete(Department Department)
        {
            _context.Remove(Department);
            _context.SaveChanges();
        }

        public IQueryable<Department> GetAll()
        {
          return  _context.Departments.AsNoTracking();
        }

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(a=>a.Id==id);
        }

        public void Update(Department Department)
        {
            _context.SaveChanges();
        }
    }
}
