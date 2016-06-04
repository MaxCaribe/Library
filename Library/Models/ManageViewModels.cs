using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Please, enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please, enter password confirmation.")]
        [StringLength(100, ErrorMessage = "Value {0} must consist of: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new Password")]
        [Compare("NewPassword", ErrorMessage = "New password and confirmation not match.")]
        public string ConfirmPassword { get; set; }
    }
}