using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Navigation
{
    public interface INavigation
    {
        event PropertyChangedEventHandler CurrentPageChanged;
        event PropertyChangedEventHandler VisibilityChanged;

        Page CurrentPage { get; set; }
        Visibility CurrentVisibility { get; set; }
        void Navigate(Page page);
        void ChangeVisibility(Visibility visibility);
    }
}
