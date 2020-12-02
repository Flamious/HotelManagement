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
                AccountId = accountData.AccountId,
                Login = accountData.Login,
                Password = accountData.Password,
                Modifier = accountData.Modifier.TrimEnd(' '),
                Surname = string.IsNullOrEmpty(accountData.Surname) ? "" : accountData.Surname.TrimEnd(' '),
                Username = string.IsNullOrEmpty(accountData.Username) ? "" : accountData.Username.TrimEnd(' '),
                Patronymic = string.IsNullOrEmpty(accountData.Patronymic) ? "" : accountData.Patronymic.TrimEnd(' ')
            };
        }
    }
}

