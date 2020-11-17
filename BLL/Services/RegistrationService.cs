using BLL.Interfaces;
using BLL.Models;
using BLL.Models.RegistrationModels;
using BLL.ServiceModules;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegistrationService : IRegistrationService
    {
        IDbManager db;
        IDbCrud dbCrud;
        public RegistrationService(IDbManager repos)
        {
            db = repos;
            dbCrud = IoC.Get<IDbCrud>();
        }
        public bool IsLoginAbsent(string login) => db.Registration.IsLoginAbsent(login);
        public string AddNewAccount(RegistrationFullData registrationFullData)
        {
            try
            {
                if (string.IsNullOrEmpty(registrationFullData.Surname)) throw new Exception("Введите фамилию");
                if (string.IsNullOrEmpty(registrationFullData.GuestName)) throw new Exception("Введите имя");
                if (string.IsNullOrEmpty(registrationFullData.PhoneNumber)) throw new Exception("Введите номер телефона");
                if (string.IsNullOrEmpty(registrationFullData.Login)) throw new Exception("Введите логин");
                if (string.IsNullOrEmpty(registrationFullData.NewPassword)) throw new Exception("Введите пароль");
                if (string.IsNullOrEmpty(registrationFullData.CheckingPassword)) throw new Exception("Подтвердите пароль");
                if (registrationFullData.CheckingPassword != registrationFullData.NewPassword) throw new Exception("Пароди не совпадают");
                //if (registrationFullData.PhoneNumber.Length != 11) throw new Exception("Телефон содержит 11 цифр");

                if (!IsLoginAbsent(registrationFullData.Login)) throw new Exception("Логин уже существет");
            }
            catch (Exception e)
            {
                return e.Message;
            }

            dbCrud.CreateAccount(new AccountModel()
            {
                Login = registrationFullData.Login,
                Password = registrationFullData.Login,
                ModifierId = 1
                //ModifierId = dbCrud.GetAllModifiers().FirstOrDefault(i => i.ModifierName == "Guest").ModifierID
            });
            dbCrud.CreateGuest(new GuestModel()
            {
                Surname = registrationFullData.Surname,
                GuestName = registrationFullData.GuestName,
                Patronymic = registrationFullData.Patronymic,
                BirthDate = registrationFullData.BirthDate,
                AccountId = dbCrud.GetAllAccounts().FirstOrDefault(i=>i.Login == registrationFullData.Login).AccountId,
                PhoneNumber = registrationFullData.PhoneNumber
            });
            return "";
        }
    }
}
