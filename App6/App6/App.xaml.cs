using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var name = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    name = "안드로이드";
                    break;
                case Device.iOS:
                    name = "아이폰";
                    break;
                default:
                    break;
            }
            //MainPage = new TabbedPage() //탭바가 생김
            MainPage = new CarouselPage() //탭바가 생기지 않음
            {
                Children =
                {
                    new FirstPage(),
                    new SecondPage(),
                    new ThirdPage("")
                }
            };
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
