using Microsoft.AspNetCore.Identity;

namespace Company_System.DAL.Models
{
    //public enum UserType
    //{
    //    SuperAdmin,Admin,User
    //}
    public class ApplicationUser : IdentityUser
    {
        public string  Address { get; set; }
        //public UserType UserType { get; set; }
    }
}
