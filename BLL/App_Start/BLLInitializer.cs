using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using DAL.Repositories.Interfaces;
using DAL.Repositories;

namespace BLL.App_Start
{
    public class BLLInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Bind<ILibraryRepository>().To<DefaultLibraryRepository>();
        }
    }
}
