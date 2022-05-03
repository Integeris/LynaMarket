using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LynaMarketMobile.Classes
{
    internal sealed class NavigatorItem
    {
        public Color Color { get; set; }   
        public int Value { get; set; }

        public NavigatorItem(int title, Color color)
        {
            Value = title;
            Color = color;
        }
    }
}
