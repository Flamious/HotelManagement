namespace BLL.Models
{
    public class AccountFullData
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Modifier { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Patronymic { get; set; }

        public string GetFullName()
        {
            return Surname + " " + Username[0] + ". " + Patronymic[0] + ". (" + Modifier + ") [id: " + AccountId + "]";
        }
    }
}
