using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWPProjekt.AssistantMechanics
{
    class ButtonSwitch
    {
        public static void activeButton(Button oneButtonNoActive, List<Button> otherButtonActive)
        {
            oneButtonNoActive.IsEnabled = false;
            foreach (Button button in otherButtonActive)
            {
                if (button.IsEnabled == false && button != oneButtonNoActive)
                    button.IsEnabled = true;
            }
        }
    }
}
