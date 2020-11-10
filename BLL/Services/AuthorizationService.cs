using BLL.Interfaces;
using BLL.Models;
using BLL.ServiceModules;
using DAL.Interfaces;

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
    }
}
