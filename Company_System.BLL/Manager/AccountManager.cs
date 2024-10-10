using Azure;
using Company_System.BLL.ViewModels;
using Company_System.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.Manager
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountManager(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseViewModel> RegisterAsync(RegisterViewModel registerVM)
        {
            var Response = new ResponseViewModel();
            ApplicationUser user = new ApplicationUser();
            user.UserName = registerVM.UserName;
            user.Email = registerVM.Email;
            user.Address=registerVM.Address;
            var result =  await _userManager.CreateAsync(user,registerVM.Password);
            if(result.Succeeded)
            {
                await _signinManager.SignInAsync(user, isPersistent: false);
                //await _userManager.AddToRoleAsync(user, "Admin");
                Response.Successed = true;
                return Response;
            }
            foreach (var error in result.Errors)
            {
                Response.Errors.Add(error.Description);
            }
            return Response;
        }
        public async Task<ResponseViewModel> LoginAsync(LoginViewModel loginVM)
        {
            var response=new ResponseViewModel();
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if(user != null)
            {
                var result =  await _signinManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe,false);
                if(result.Succeeded)
                {
                    response.Successed = true;
                    return response;
                }
            }
            response.Errors.Add("Wrong Password or UserName");
            return response ;
        }

        public async Task LogOutAsync()
        {
            await _signinManager.SignOutAsync();
        }

        public async Task<ResponseViewModel> CreateRoleAsync(RoleViewModel roleVM)
        {
            ResponseViewModel response = new ResponseViewModel();
            IdentityRole role = new IdentityRole();
            role.Name = roleVM.RoleName;

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                response.Successed = true;
                return response;
            }
            foreach (var error in result.Errors)
            {
                response.Errors.Add(error.Description);
            }
            return response;
        }

        public async Task<ResponseViewModel> AssignRoleToUserAsync(RoleToUserViewModel roleToUserVM)
        {
            var response = new ResponseViewModel();
            var roleIdentity = await _roleManager.FindByIdAsync(roleToUserVM.RoleId);
            var user = await _userManager.FindByIdAsync(roleToUserVM.UserId);

            var result = await  _userManager.AddToRoleAsync(user, roleIdentity.Name);
            if(result.Succeeded)
            {
                response.Successed = true;
                return response;
            }
            foreach(var error in result.Errors)
            {
                response.Errors.Add(error.Description);
            }
            return response;
        }
    }
}
