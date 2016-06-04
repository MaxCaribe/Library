using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, enter correct email.")]
        [EmailAddress(ErrorMessage = "Please, enter correct email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please, enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please, enter your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please, enter correct email.")]
        [EmailAddress(ErrorMessage = "Please, enter correct email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter password.")]
        [StringLength(100, ErrorMessage = "Value {0} must consist of not less than {2} symbols.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation not match")]
        public string ConfirmPassword { get; set; }
    }
}