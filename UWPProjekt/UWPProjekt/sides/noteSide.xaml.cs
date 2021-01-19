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
using DataAccessLibrary;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPProjekt.sides
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class noteSide : Page
    {
        public noteSide()
        {
            this.InitializeComponent();
        }

        private void SaveNoteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //zapisz button


            string c = calendarNote.SelectedDates.FirstOrDefault().ToString();

            string z = "";
            for (int i = 0; i < 10; i++)
            {
                if (c[i] == ' ')
                    break;
                else
                    z += c[i];

            }
            
            //Output.ItemsSource = Class1.GetData();
            //textbox.Text = Class1.GetData2();
            Class1.AddData(contentNoteTextBlock.Text, z);

        }

        private void OpenTextFile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //odczyt button

            string c = calendarNote.SelectedDates.FirstOrDefault().ToString();

            string z = "";
            for (int i = 0; i < 10; i++)
            {
                if (c[i] == ' ')
                    break;
                else
                    z += c[i];

            }
            string key = z;
       contentNoteTextBlock.Text = Class1.GetData2(key);

        }
    }
}
