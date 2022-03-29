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

[assembly: ExportRenderer(typeof(CarouselView), typeof(LynaMarketMobile.Droid.CarouselViewRenderer))]
namespace LynaMarketMobile.Droid
{
    public class CarouselViewRenderer : Xamarin.Forms.Platform.Android.CarouselViewRenderer
    {
        public CarouselViewRenderer(Context context) : base(context) { }

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