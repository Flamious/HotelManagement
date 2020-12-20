using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;

namespace BLL.ServiceModules
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DbCrud>().InSingletonScope();
            Bind<IDbManager>().To<DbManager>().InSingletonScope();
            Bind<IAuthorizationService>().To<AuthorizationService>().InSingletonScope();
            Bind<ICheckInService>().To<CheckInService>().InSingletonScope();
            Bind<IDbInfo>().To<DbInfoService>().InSingletonScope();
        }
    }
}
