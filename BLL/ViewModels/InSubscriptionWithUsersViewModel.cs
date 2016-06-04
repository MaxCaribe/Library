using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class InSubscriptionWithUsersViewModel
    {
        public IEnumerable<InSubscriptionsViewModel> Subscriptions { get; set; }
        public UserViewModel User { get; set; }
    }
}