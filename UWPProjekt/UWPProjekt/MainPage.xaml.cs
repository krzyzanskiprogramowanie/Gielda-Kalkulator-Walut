using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPProjekt.AssistantMechanics;
using UWPProjekt.sides;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPProjekt
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<RelativePanel> flatButtons = new List<RelativePanel>();
        private List<Button> groupButtons = new List<Button>();
        private List<string> imageSource = new List<string>();
        public MainPage()
        {
            this.InitializeComponent();

            ScreenView.Navigate(typeof(homeSide));
            flatButtons.Add(blockPanelHo);
            flatButtons.Add(blockPanelCH);
            flatButtons.Add(blockPanelEx);
            flatButtons.Add(blockPanelNo);
            flatButtons.Add(blockPanelQu);

            groupButtons.Add(home);
            groupButtons.Add(cash);
            groupButtons.Add(exchange);
            groupButtons.Add(notebook);
            groupButtons.Add(question);

            imageSource.Add(@"ms-appx:///Assets/ikons/house.png");
            imageSource.Add(@"ms-appx:///Assets/ikons/money.png");
            imageSource.Add(@"ms-appx:///Assets/ikons/exchange.png");
            imageSource.Add(@"ms-appx:///Assets/ikons/notebook.png");
            imageSource.Add(@"ms-appx:///Assets/ikons/qustion.png");

            SetButtonItems.setIcons(groupButtons, imageSource);
        }

        private void Logo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenView.Navigate(typeof(homeSide));
            ChangeMechanic.chageFlatPoint(flatButtons, blockPanelHo);
            ButtonSwitch.activeButton(home, groupButtons);
        }

        private void Home_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenView.Navigate(typeof(homeSide));
            ChangeMechanic.chageFlatPoint(flatButtons, blockPanelHo);
            ButtonSwitch.activeButton(home, groupButtons);
        }

        private void Cash_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenView.Navigate(typeof(cashSide));
            ChangeMechanic.chageFlatPoint(flatButtons, blockPanelCH);
            ButtonSwitch.activeButton(cash, groupButtons);
        }

        private void Exchange_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenView.Navigate(typeof(exchangeSide));
            ChangeMechanic.chageFlatPoint(flatButtons, blockPanelEx);
            ButtonSwitch.activeButton(exchange, groupButtons);
        }

        private void Notebook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenView.Navigate(typeof(noteSide));
            ChangeMechanic.chageFlatPoint(flatButtons, blockPanelNo);
            ButtonSwitch.activeButton(notebook, groupButtons);
        }

        private void Question_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ScreenView.Navigate(typeof(questionSide));
            ChangeMechanic.chageFlatPoint(flatButtons, blockPanelQu);
            ButtonSwitch.activeButton(question, groupButtons);
        }
    }
}
