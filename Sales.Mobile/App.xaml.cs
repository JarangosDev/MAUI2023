using Sales.Mobile.MVVM.Views;

namespace Sales.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PersonView());
        }
    }
}