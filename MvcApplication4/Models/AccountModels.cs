using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace SLT.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא נוכחית")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = ".{0} צריכה להיות בעלת {2} תווים לפחות", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "הסיסמא החדשה")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "אמת סיסמא חדשה")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = ".אימות הסיסמא אינו תואם")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "שם משתמש")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }

        [Display(Name = "זכור אותי")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
