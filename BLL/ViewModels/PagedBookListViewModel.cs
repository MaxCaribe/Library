using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.ViewModels;

namespace Library.Models
{
    public class PagedBookListViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}