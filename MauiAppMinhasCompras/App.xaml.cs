using Android.Views;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}