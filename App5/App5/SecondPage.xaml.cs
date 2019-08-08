using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }
        ModalPage modalPage;
        public async void btn_Back_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            modalPage = new ModalPage(entry_Name.Text);
            await Navigation.PushModalAsync(modalPage);
        }
        public async void btn_Next_Clicked(object sender, EventArgs e)
        {
            if (modalPage == null || modalPage.Age < 0)
            {
                await DisplayAlert("Please Insert Age", "You must insert Age,", "OK");
                return;
            }
            await Navigation.PushAsync(new ThirdPage(entry_Name.Text, modalPage.Age));
        }
    }
}