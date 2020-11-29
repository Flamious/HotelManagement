using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceModules
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DbCrud>().InSingletonScope();
            Bind<IDbManager>().To<DbManager>().InSingletonScope();
            Bind<IConvertationService>().To<ConvertationService>().InSingletonScope();
            Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            Bind<ICheckInMakingRepository>().To<CheckInMakingRepository>().InSingletonScope();
            Bind<ICheckInService>().To<CheckInService>().InSingletonScope();
        }
    }
}
