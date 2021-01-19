using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPProjekt.sides
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class cashSide : Page
    {
        public cashSide()
        {
            this.InitializeComponent();
            CashSide.Navigate(typeof(RateCashSide));
        }

        private void RateCashButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CashSide.Navigate(typeof(RateCashSide));
        }

        private void GraphCashButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CashSide.Navigate(typeof(GraphCashSide));
        }

        private void ReadYourCash(object sender, TappedRoutedEventArgs e)
        {
            CashSide.Navigate(typeof(YourCurrencyList));
        }
    }
}
