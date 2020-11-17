using BLL.Models;
using BLL.Models.RegistrationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegistrationService
    {
        bool IsLoginAbsent(string login);
        string AddNewAccount(RegistrationFullData registrationFullData);
    }
}
