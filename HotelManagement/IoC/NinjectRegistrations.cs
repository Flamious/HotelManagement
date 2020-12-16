using HotelManagement.CheckInMaking;
using HotelManagement.CompleteCheckInModel;
using HotelManagement.DirectorPageData;
using HotelManagement.Employee;
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
            Bind<ICheckInRoom>().To<CheckInRoom>().InSingletonScope();
            Bind<ICompleteCheckIn>().To<CompleteCheckIn>().InSingletonScope();
            Bind<ICheckInGuest>().To<CheckInGuest>().InSingletonScope();
            Bind<IEmployee>().To<EmployeeProperties>().InSingletonScope();
            Bind<IDirector>().To<Director>().InSingletonScope();
        }
    }
}
