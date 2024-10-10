using Company_System.BLL.Manager;
using Company_System.Database;
using Company_System.Models;
using Company_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Company_System.Controllers
{
    [Authorize]
    //[Authorize(Roles ="Admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;

        public EmployeesController(IEmployeeManager employeeManager,IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }
        [AllowAnonymous]
        public IActionResult GetAllDeparments()
        {
            return View(_departmentManager.GetAll());
        }
        public IActionResult GetAllVM()
        {
            return View(_employeeManager.GetAll());
        }
        //public IActionResult GetAllJson(int Id)
        //{
        //    var emps = _context.Employees.Where(a=>a.DepartmentId == Id).Select(a => new EmployeeReadVM
        //    {
        //        Id = a.Id,
        //        Name = a.Name,
        //    }).ToList();

        //    return Json(emps);
        //}
        public IActionResult GetByID(int id)
        {
            return PartialView(_employeeManager.GetById(id));
        }
        [HttpGet]
        public IActionResult CreateNew()
        {
            return View(_departmentManager.GetAll());
        }
        [HttpPost]
        public IActionResult CreateNew([FromForm] EmployeeAddVM employeevm)
        {   
            
            _employeeManager.Add(employeevm);
            //CheckImageAndUpload(employeevm.ImgUrl);
            return RedirectToAction("GetAllVM");
        }
        private  void CheckImageAndUpload(IFormFile Image)
        {
            if (Image != null)
            {
                // Define the path where the file will be saved
                var uploadsFolderUrl = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                // Ensure the uploads directory exists
                if (!Directory.Exists(uploadsFolderUrl))
                {
                    Directory.CreateDirectory(uploadsFolderUrl);
                }
                // Create the full path for the file
                var filePath = Path.Combine(uploadsFolderUrl, Image.FileName);
                // Save the file


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Image.CopyToAsync(stream);
                }
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var empWithDepts = new EmployeeWithDepartmentVM
            {
                Employee = _employeeManager.GetById(id),
                Departments = _departmentManager.GetAll()
            };

            return View(empWithDepts);
        }
        [HttpPost]
        public IActionResult Edit(int id,Employee employee)
        {
            if(id==employee.Id)
            {
                //_employeeManager.Update(employee);
                return RedirectToAction("GetAllVM");
            }
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            _employeeManager.Delete(id);
            return RedirectToAction("GetAllVM");
        }
    }
}
