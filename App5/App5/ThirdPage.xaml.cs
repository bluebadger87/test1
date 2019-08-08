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
	public partial class ThirdPage : ContentPage
	{
public ThirdPage (string name, int age)
{
	InitializeComponent ();
    label_text.Text = string.Format("Hello! {0}({1})", name, age);
}
        
public async void btn_GotoTop_Clicked(object sender, EventArgs e)
{
    await Navigation.PopToRootAsync();
}

    }
}