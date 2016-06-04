using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class NewViewModel
    {
        public IEnumerable<InSubscriptionsViewModel> Subscriptions { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}