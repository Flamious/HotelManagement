using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        IDbManager db;
        public AuthorizationService(IDbManager repos)
        {
            db = repos;
        }
        public AccountFullData FindAccount(string login, string password)
        {
            var result = db.Accounts.GetList()
            .Join(db.Modifiers.GetList(), i => i.ModifierId, j => j.ModifierId, (i, j) => new AccountFullData()
            {
                AccountId = i.AccountId,
                Login = i.Login.TrimEnd(' '),
                Password = i.Password.TrimEnd(' '),
                Modifier = j.ModifierName.TrimEnd(' '),
                Surname = string.IsNullOrEmpty(i.Surname) ? "" : i.Surname.TrimEnd(' '),
                Username = string.IsNullOrEmpty(i.Username) ? "" : i.Username.TrimEnd(' '),
                Patronymic = string.IsNullOrEmpty(i.Patronymic) ? "" : i.Patronymic.TrimEnd(' ')
            });
            return result.FirstOrDefault(i => i.Login == login && i.Password == password);
        }

    }
}
