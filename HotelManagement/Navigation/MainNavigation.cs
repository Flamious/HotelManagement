using System.ComponentModel;
using System.Windows.Controls;

namespace HotelManagement.Navigation
{
    public class MainNavigation : INavigation
    {
        public event PropertyChangedEventHandler CurrentPageChanged;

        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                CurrentPageChanged?.Invoke(null, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public void Navigate(Page page)
        {
            CurrentPage = page;
        }
    }
}
