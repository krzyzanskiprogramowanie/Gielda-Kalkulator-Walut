using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace UWPProjekt.AssistantMechanics
{
    class ChangeMechanic
    {
        public static void chageFlatPoint(List<RelativePanel> flatPoints, RelativePanel flagNoChange)
        {
            foreach (RelativePanel flatpoint in flatPoints)
            {
                if (flatpoint == flagNoChange)
                    flatpoint.Visibility = Visibility.Visible;
                else
                    flatpoint.Visibility = Visibility.Collapsed;
            }
        }
    }
}
