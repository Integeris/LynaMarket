using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LynaMarketMobile.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Тип или член устарел
[assembly: ExportRenderer(typeof(Grid), typeof(UserGridRenderer))]
#pragma warning restore CS0612 // Тип или член устарел
namespace LynaMarketMobile.Droid
{
    [Obsolete]
    internal class UserGridRenderer : ViewRenderer<Xamarin.Forms.Grid, Android.Widget.GridView>
    {
        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            if (ev.Action == MotionEventActions.Move)
            {
                this.Parent.RequestDisallowInterceptTouchEvent(true);
            }

            return base.OnInterceptTouchEvent(ev);
        }
    }
}