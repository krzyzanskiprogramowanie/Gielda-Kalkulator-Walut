using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using UWPProjekt.Tabele;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPProjekt.AssistantMechanics;
using DataAccessLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPProjekt.sides
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RateCashSide : Page
    {
        const string adresDanych = "https://www.nbp.pl/kursy/xml/LastA.xml";
        List<ArrayPosition> CurrentCourse = new List<ArrayPosition>();
        private string[] arrayWords = new string[5];

        public RateCashSide()
        {
            this.InitializeComponent();
            txtKwota.PlaceholderText = $"{0:f2}";
            tbPrzeliczona.Text = $"{0:f2}";
            ReadDataNBP();
            ZapiszKurs.IsEnabled = false;

        }
        async void ReadDataNBP()
        {
            string DataNBP = "";
            HttpClient ourPostman = new HttpClient();
            try
            {
                DataNBP = await ourPostman.GetStringAsync(new Uri(adresDanych));
            }
            catch (Exception e)
            {
                MessageDialog dlgError = new MessageDialog(e.Message, "DANE");
                await dlgError.ShowAsync();
                App.Current.Exit();
            }
            try
            {
                XDocument daneNBPxml = XDocument.Parse(DataNBP);
                CurrentCourse = (from item in daneNBPxml.Descendants("pozycja")
                                 select new ArrayPosition
                                 {
                                     kod_waluty = item.Element("kod_waluty").Value,
                                     kurs_sredni = item.Element("kurs_sredni").Value,
                                     przelicznik = item.Element("przelicznik").Value
                                 }).ToList();
                CurrentCourse.Insert(0, new ArrayPosition { kod_waluty = "PLN", kurs_sredni = "1,0000", przelicznik = "1" });
                lbxZWaluty.ItemsSource = CurrentCourse;
                lbxNaWalute.ItemsSource = CurrentCourse;
                lbxNaWalute.SelectedIndex = 0;
                lbxZWaluty.SelectedIndex = 0;
            }
            catch (Exception)
            { MessageDialog dlgError = new MessageDialog("Brak polaczenia z internetem", "Dane");
                await dlgError.ShowAsync();
            }
        }

        private void txtKwota_TextChanged(object sender, TextChangedEventArgs e)
        {
            Przelicz();
            ZapiszKurs.IsEnabled = true;
        }

        private void Przelicz()
        {
            double kwota;
            string walutaNa = "", walutaZ = "";
            if (double.TryParse(txtKwota.Text, out kwota))
            {
                kwota = ((ArrayPosition)lbxZWaluty.SelectedItem).CountForNBP(kwota, true);
                kwota = ((ArrayPosition)lbxNaWalute.SelectedItem).CountForNBP(kwota, false);
                walutaNa = ((ArrayPosition)lbxNaWalute.SelectedItem).kod_waluty;
                walutaZ = ((ArrayPosition)lbxZWaluty.SelectedItem).kod_waluty;
            }
            tbPrzeliczona.Text = $"{kwota:f2}";
            CatchCurrencyOn.Text = $"{walutaNa}";
            CatchCurrencyFrom.Text = $"{walutaZ}";

            arrayWords[0] = ustawaDate();
            arrayWords[1] = CatchCurrencyFrom.Text; 
            arrayWords[2] = txtKwota.Text;
            arrayWords[3] = CatchCurrencyOn.Text;
            arrayWords[4] =  tbPrzeliczona.Text;
        }

        private void waluty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Przelicz();
        }

        public string ustawaDate()
        {
            string date = "";
            date += DateTime.Today.Day.ToString() + "-";
            date += DateTime.Today.Month.ToString() + "-";
            date += DateTime.Today.Year.ToString();
            return date;
        }
        string YourExchange = "";

        async void send()
        {
           string word = "Zapisano w historii";
            var dialog = new MessageDialog(word);
            await dialog.ShowAsync();
        }
        private void ZapiszKurs_Tapped(object sender, TappedRoutedEventArgs e)
        {
           YourExchange=ConcatInformation.toSave(arrayWords);
            send();
            Class1.AddData10("YourCashHistory", YourExchange);
        }
    }
}
