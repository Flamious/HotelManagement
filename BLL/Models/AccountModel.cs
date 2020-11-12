using DAL;

namespace BLL.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ModifierId { get; set; }

        public AccountModel() { }
        public AccountModel(Account account)
        {
            AccountId = account.AccountId;
            Login = account.Login;
            Password = account.Password;
            ModifierId = account.ModifierId;
        }
    }
}
