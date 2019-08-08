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
	public partial class ModalPage : ContentPage
	{

        public int Age { get; set; }
        public ModalPage (string name)
		{
			InitializeComponent ();
            Age = -1;
            if (string.IsNullOrEmpty(name))
                name = "Your";
            label_Name.Text = "Insert" + name + "Age";
		}
        public async void btn_ModalOK_Clicked(object sender, EventArgs e)
        {
            Age = Convert.ToInt32(entry_Age.Text);
            await Navigation.PopModalAsync();
        }
        public async void btn_ModalCancel_Clicked(object sender, EventArgs e)
        {
            Age = -1;
            await Navigation.PopModalAsync();
        }
    }
}