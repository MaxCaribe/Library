using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Key]
        [MaxLength(128)]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        public IList<IdentityUserRole> Roles { get; set; }

        public string SelectedRole { get; set; }
    }
}