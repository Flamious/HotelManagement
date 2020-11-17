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

    }
}
