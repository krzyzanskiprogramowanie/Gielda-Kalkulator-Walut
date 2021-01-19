using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPProjekt.AssistantMechanics
{
    class SetButtonItems
    {
        public static void setIcons(List<Button> buttons, List<string> icons)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(icons[i]));
                buttons[i].Content = image;
            }
        }
    }
}
