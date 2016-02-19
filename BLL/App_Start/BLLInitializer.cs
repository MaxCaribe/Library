using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
using DAL.Models;
using BLL.ViewModels;
using BLL.Services.Interfaces;
using BLL.Services;
using AutoMapper;

namespace BLL.App_Start
{
    public class BLLInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Bind<ILibraryService>().To<LibraryService>();
            kernel.Bind<ILibraryRepository>().To<DefaultLibraryRepository>();
            Mapper.CreateMap<Book, BookViewModel>();
        }
    }
}
