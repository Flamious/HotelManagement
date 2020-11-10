using DAL.Entities;
using DAL.Interfaces;
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
                .Join(db.Modifier, i => i.ModifierID, j => j.ModifierID, (i, j) => new AccountData()
                {
                    AccountID = i.AccountID,
                    Login = i.Login,
                    Password = i.Password,
                    Modifier = j.ModifierName
                })
                .FirstOrDefault(i => i.Login == login && i.Password == password);
        }

        public GuestData FindGuest(int accountId)
        {
            return db.Guest
                .Join(db.Account, i => i.AccountID, j => j.AccountID, (i, j) => new GuestData()
                {
                    GuestID = i.GuestID,
                    Surname = i.Surname,
                    GuestName = i.GuestName,
                    Patronymic = i.Patronymic,
                    BirthDate = i.BirthDate,
                    PhoneNumber = i.PhoneNumber,
                    AccountID = j.AccountID,
                    Login = j.Login,
                    Password = j.Password
                })
                .FirstOrDefault(i => i.AccountID == accountId);
        }
    }
}
