using BLL.Interfaces;
using BLL.Models;
using BLL.ServiceModules;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        IDbManager db;
        IConvertationService convertationService;
        public AuthorizationService(IDbManager repos)
        {
            db = repos;
            convertationService = IoC.Get<IConvertationService>();
        }
        public AccountFullData FindAccount(string login, string password)
        {
            return convertationService.Convert(db.Login.FindAccount(login, password));
        }

        public GuestFullData FindGuest(int accountId)
        {
            return convertationService.Convert(db.Login.FindGuest(accountId));
        }

        public List<GuestCheckInFullData> FindAllCheckIns(int guestid)
        {
            return convertationService.Convert(db.Login.FindAllPreviousCheckIns(guestid));
        }

        public GuestCheckInFullData FindClosestCheckIn(int guestId)
        {
            return convertationService.Convert(db.Login.FindClosestCheckIn(guestId));
        }
    }
}
