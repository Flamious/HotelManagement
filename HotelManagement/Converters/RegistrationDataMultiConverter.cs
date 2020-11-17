using BLL.Models;
using HotelManagement.Structures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HotelManagement.Converters
{
    public class RegistrationDataMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new RegistrationData()
            {
                CurrentPassword = values[0] as PasswordBox,
                NewPassword = values[1] as PasswordBox,
                CheckingPassword = values[2] as PasswordBox
            };

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new Exception();
            //RegistrationData data = value as RegistrationData;
            //return new object[]
            //{
            //    data.Surname,
            //    data.GuestName,
            //    data.Patronymic,
            //    data.BirthDate,
            //    data.PhoneNumber,
            //    data.Login,
            //    data.CurrentPassword
            //};
        }
    }
}
