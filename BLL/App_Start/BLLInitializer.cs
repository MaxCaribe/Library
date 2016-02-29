using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using BLL.ViewModels;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.App_Start
{
    public class BLLInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Bind<ILibraryService>().To<LibraryService>();
            kernel.Bind<ILibraryRepository>().To<DefaultLibraryRepository>();
            Mapper.CreateMap<Book, BookViewModel>();
            Mapper.CreateMap<BookViewModel, Book>();
            Mapper.CreateMap<ApplicationUser, UserViewModel>();
            Mapper.CreateMap<InSubscription, InSubscriptionsViewModel>();
        }
    }
}