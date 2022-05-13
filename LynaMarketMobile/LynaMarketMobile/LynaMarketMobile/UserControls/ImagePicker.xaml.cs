using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LynaMarketMobile.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePicker : ContentView
    {
        private int currnentItem = 0;
        private readonly List<ImageSource> images = new List<ImageSource>();

        public int CurrentnentItem
        {
            get => currnentItem;
            set
            {
                MainImage.Source = images[value];
                currnentItem = value;
            }
        }

        public List<ProductPhoto> Images
        {
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Недопустимое значение свойства.");
                }

                images.Clear();

                foreach (var item in value)
                {
                    images.Add(ImageSource.FromStream(() => new MemoryStream(item.Image)));
                }

                CurrentnentItem = 0;
            }
        }

        public ImagePicker()
        {
            InitializeComponent();
        }

        private void BackButtonOnClicked(object sender, EventArgs e)
        {
            if (images.Count == 0)
            {
                return;
            }

            if (currnentItem == 0)
            {
                CurrentnentItem = images.Count - 1;
            }
            else
            {
                CurrentnentItem--;
            }
        }

        private void NextButtonOnClicked(object sender, EventArgs e)
        {
            if (images.Count == 0)
            {
                return;
            }

            if (currnentItem == images.Count - 1)
            {
                CurrentnentItem = 0;
            }
            else
            {
                CurrentnentItem++;
            }
        }
    }
}