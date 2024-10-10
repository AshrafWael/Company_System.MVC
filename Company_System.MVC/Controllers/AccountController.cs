using Company_System.BLL.Manager;
using Company_System.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel registerVM)
        {
            var response=   await _accountManager.RegisterAsync(registerVM);
            if(response.Successed == true)
            {
               return RedirectToAction("Login");
            }
            foreach (var item in response.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return View(registerVM);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginVM)
        {
            var response = await _accountManager.LoginAsync(loginVM);
            if (response.Successed == true)
            {
                return RedirectToAction("GetAllVM", "Employees");
            }
            ModelState.AddModelError("", response.Errors.First());
            return View(loginVM);
        }
        public async Task<IActionResult> LogOutAsync()
        {
            await _accountManager.LogOutAsync();
            return RedirectToAction("LoginAsync");
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(RoleViewModel roleVM)
        {
            var result=  await _accountManager.CreateRoleAsync(roleVM);
            if(result.Successed==true)
            {
                return RedirectToAction("GetAllRoles");
            }
            foreach(var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return View(roleVM);
        }
        public IActionResult AssignRoleToUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUserAsync(RoleToUserViewModel roleToUserVM)
        {
            var result = await _accountManager.AssignRoleToUserAsync(roleToUserVM);
            if (result.Successed == true)
            {
                return RedirectToAction("GetAllRoles");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
            return View(roleToUserVM);
        }
    }
}
