using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ConvertationService : IConvertationService
    {
        public AccountFullData Convert(AccountData accountData)
        {
            return accountData == null ? null : new AccountFullData()
            {
                AccountID = accountData.AccountID,
                Login = accountData.Login,
                Password = accountData.Password,
                Modifier = accountData.Modifier
            };
        }
    }
}

