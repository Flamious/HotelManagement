using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private HotelDB db;

        public LoginRepository(HotelDB dbcontext)
        {
            this.db = dbcontext;
        }
        public AccountData FindAccount(string login, string password)
        {
            return db.Account
                .Join(db.Modifier, i => i.ModifierId, j => j.ModifierId, (i, j) => new AccountData()
                {
                    AccountId = i.AccountId,
                    Login = i.Login,
                    Password = i.Password,
                    Modifier = j.ModifierName,
                    Surname = i.Surname,
                    Username = i.Username,
                    Patronymic = i.Patronymic
                })
                .FirstOrDefault(i => i.Login == login && i.Password == password);
        }
    }
}
