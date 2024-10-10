using Company_System.DAL.Models;
using Company_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Company_System.Database
{
    public class Company_SystemContext : IdentityDbContext<ApplicationUser>
    {
        public Company_SystemContext(DbContextOptions<Company_SystemContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server = . ; database=CompanyCompany_System ; Integrated Security =true; Encrypt=false;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var depts = new List<Department>
            {
                new Department {Id=1,Name="IT"},
                new Department {Id=2,Name="IS"},
                new Department {Id=3,Name="CS"},
                new Department {Id=4,Name="HR"},
            };

            modelBuilder.Entity<Department>().HasData(depts);

            var emps = new List<Employee>
            {
                new Employee{Id=1,Name="ahmed",Age=25,Salary=5000,ImgUrl="1.png",DepartmentId=1},
                new Employee{Id=2,Name="ayman",Age=27,Salary=10000,ImgUrl="2.png",DepartmentId=2},
                new Employee{Id=3,Name="yasser",Age=28,Salary=8000,ImgUrl="3.png",DepartmentId=3},
                new Employee{Id=4,Name="yara",Age=29,Salary=7000,ImgUrl="1.png",DepartmentId=4},
                new Employee{Id=5,Name="tamer",Age=25,Salary=6000,ImgUrl="2.png",DepartmentId=1},
            };

            modelBuilder.Entity<Employee>().HasData(emps);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
