﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

public async void btn_NextPage_Clicked(object sender, EventArgs e)
{
    await Navigation.PushAsync(new SecondPage());
}
    }
}
