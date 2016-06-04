using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.ViewModels
{
    public class UserListViewModel
    {
        public IList<UserViewModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}