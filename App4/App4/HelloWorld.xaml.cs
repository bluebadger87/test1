using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelloWorld : ContentPage
    {
        public HelloWorld()
        {
            InitializeComponent();
        }

        public void btn_SayHello_Clicked(object sender, EventArgs e)
        {
            var name = entry_Name.Text;
            label_Hello.Text = "Hello! " + name;
        }

        public void btn_Reset_Clicked(object sender, EventArgs e)
        {
            label_Hello.Text = "Hello! EveryOne";
        }
    }
}