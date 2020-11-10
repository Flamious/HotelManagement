using HotelManagement.Navigation;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.ViewModels
{
    class VMMainWindow : VMBase
    {
        private readonly INavigation navigation;

        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;
        public VMMainWindow()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.Navigate(new LoginPage());
            navigation.ChangeVisibility(Visibility.Visible);
        }
    }
}
