using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using App2;
using App2.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomView), typeof(CustomRenderer_android))]
namespace App2.Droid
{
    public class CustomRenderer_android : ViewRenderer<CustomView, Android.Widget.DatePicker>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomView> e)
        {
            base.OnElementChanged(e);

            var datePicker = new Android.Widget.DatePicker(Forms.Context);

            SetNativeControl(datePicker);
        }
    }
}