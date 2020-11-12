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
        public FoundAccount FindAccount(string login, string password)
        {
            return convertationService.Convert(db.Login.FindAccount(login, password));
        }

        public FoundGuest FindGuest(int accountId)
        {
            return convertationService.Convert(db.Login.FindGuest(accountId));
        }

        public List<FoundGuestCheckIn> FindAllCheckIns(int guestid)
        {
            return convertationService.Convert(db.Login.FindAllPreviousCheckIns(guestid));
        }

        public FoundGuestCheckIn FindClosestCheckIn(int guestId)
        {
            return convertationService.Convert(db.Login.FindClosestCheckIn(guestId));
        }
    }
}
