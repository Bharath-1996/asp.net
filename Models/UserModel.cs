using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First name is required")]
        [Display(Name ="first name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "last name is required")]
        [Display(Name = "last name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "confirm password is required")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="password and confirm password is same")]
        public string Confirmpassword { get; set; }
        public DateTime CreateOn { get; set; }
        public string message { get; set; }
    }
}