using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone: //1
                    MainPage = new MainPage();
                    break;
                case TargetIdiom.Tablet: //2
                    break;
                case TargetIdiom.Desktop: //3
                    MainPage = new Page_Desktop();
                    break;
                case TargetIdiom.TV: //4
                    break;
                default:
                    break;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
