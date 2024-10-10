using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 10)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
