using Company_System.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.Manager
{
    public interface IAccountManager
    { 
        Task<ResponseViewModel> RegisterAsync(RegisterViewModel registerVM);
        Task<ResponseViewModel> LoginAsync(LoginViewModel loginVM);
        Task LogOutAsync();
        Task<ResponseViewModel> CreateRoleAsync(RoleViewModel roleVM);
        Task<ResponseViewModel> AssignRoleToUserAsync(RoleToUserViewModel roleToUserVM);
    }

}
