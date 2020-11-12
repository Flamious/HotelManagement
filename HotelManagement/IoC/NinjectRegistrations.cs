using HotelManagement.Guest;
using HotelManagement.Navigation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<INavigation>().To<MainNavigation>().InSingletonScope();
            Bind<IGuest>().To<CurrentGuest>().InSingletonScope();
        }
    }
}
