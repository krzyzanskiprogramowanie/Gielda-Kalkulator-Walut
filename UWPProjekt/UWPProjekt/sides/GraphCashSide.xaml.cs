using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using UWPProjekt.Tabele;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPProjekt.sides
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GraphCashSide : Page
    {
        int Counter = 0;
        List<ArrayPosition> CurrentCurs = new List<ArrayPosition>();
        string[] tabAddress = new string[7];
        decimal[] tabTHB = new decimal[7];
        decimal[] tabUSD = new decimal[7];
        decimal[] tabAUD = new decimal[7];
        decimal[] tabHKD = new decimal[7];
        decimal[] tabCAD = new decimal[7];
        decimal[] tabNZD = new decimal[7];
        decimal[] tabSGD = new decimal[7];
        decimal[] tabEUR = new decimal[7];
        decimal[] tabHUF = new decimal[7];
        decimal[] tabCHF = new decimal[7];
        decimal[] tabGBP = new decimal[7];
        decimal[] tabUAH = new decimal[7];
        decimal[] tabJPY = new decimal[7];
        decimal[] tabCZK = new decimal[7];
        decimal[] tabDKK = new decimal[7];
        decimal[] tabISK = new decimal[7];
        decimal[] tabNOK = new decimal[7];
        decimal[] tabSEK = new decimal[7];
        decimal[] tabHRK = new decimal[7];
        decimal[] tabRON = new decimal[7];
        decimal[] tabBGN = new decimal[7];
        decimal[] tabTRY = new decimal[7];
        decimal[] tabILS = new decimal[7];
        decimal[] tabCLP = new decimal[7];
        decimal[] tabPHP = new decimal[7];
        decimal[] tabMXN = new decimal[7];
        decimal[] tabZAR = new decimal[7];
        decimal[] tabBRL = new decimal[7];
        decimal[] tabMYR = new decimal[7];
        decimal[] tabRUB = new decimal[7];
        decimal[] tabIDR = new decimal[7];
        decimal[] tabINR = new decimal[7];
        decimal[] tabKRW = new decimal[7];
        decimal[] tabCNY = new decimal[7];
        decimal[] tabXDR = new decimal[7];


        string ComboBoxText = "THB";
        public GraphCashSide()
        {
            this.InitializeComponent();
            ComboBoxValue();
            PageAlgorithm();
          
          
        }
        public void PageAlgorithm()
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            int day = DateTime.Today.Day;
            // Tutaj.Text =year;
            DateTime date1 = new DateTime(year, 1, 1);
            DateTime date2 = new DateTime(year, month, day);
            TimeSpan difference = date2 - date1;
            string number = difference.ToString();


            //szczególny przypadek gdy różnica wynosi 0
            string DifferenceDayYear = "";
            for (int i = 0; i < 5; i++)
            {
                if (number[i] == '.')
                    break;
                else if (number[0] == '0')
                    DifferenceDayYear = "0";
                else
                    DifferenceDayYear += number[i];

            }





            int DayYear = Convert.ToInt32(DifferenceDayYear);

            float NumberWeeks = (DayYear / 7.0f);

            int DayWeeks = (int)NumberWeeks;
            int WithoutWeekends = DayWeeks * 2;
            DayYear -= WithoutWeekends;
            int DayYearWithoutWeekends = DayYear;


            string NowYear = DateTime.Now.Year.ToString();



            string YearEndNumber = "";
            for (int i = 2; i < 4; i++)
                YearEndNumber += NowYear[i];




            int Day = DateTime.Now.Day;
            int Month = DateTime.Now.Month;

            int YearEndingNumber = Convert.ToInt32(YearEndNumber);
            for (int i = 0; i < 14; i++)
            {


                if (Day <= 1)
                {

                    if (Month > 1)
                    {

                        Month -= 1;
                        if (Month == 2)
                        {
                            if (YearEndingNumber % 4 == 0)
                                Day = 29;
                            else
                                Day = 28;
                        }
                        else if (Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                            Day = 31;
                        else if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                            Day = 30;


                    }
                    else
                    {
                        YearEndingNumber -= 1;
                        Month = 12;
                        Day = 31;
                    }
                }
                else
                {

                    Day--;

                }

                string DayText = Day.ToString();
                string MonthText = Month.ToString();
                string YearText = YearEndingNumber.ToString();
                if (DayText.Length < 2)
                    DayText = "0" + DayText;
                if (MonthText.Length < 2)
                    MonthText = "0" + MonthText;
                string TextDate = YearText + MonthText + DayText;
                for (int j = 1; j <= 15; j++)
                {

                    DayYear = DayYearWithoutWeekends;
                    DayYear -= j;


                    if (DayYear < 10 && Counter < 7)
                    {

                        string AdresWebSite = $"http://www.nbp.pl/kursy/xml/a00{DayYear}z{TextDate}.xml";
                        IsValidUri(new Uri(AdresWebSite), AdresWebSite);

                    }
                    else if (DayYear < 100 && DayYear >= 10 && Counter < 7)
                    {
                        string AdresWebsite = $"http://www.nbp.pl/kursy/xml/a0{DayYear}z{TextDate}.xml";

                        IsValidUri(new Uri(AdresWebsite), AdresWebsite);


                    }
                    else if (DayYear >= 100 && Counter < 7)
                    {
                        string AdresWebSite = $"http://www.nbp.pl/kursy/xml/a{DayYear}z{TextDate}.xml";


                        IsValidUri(new Uri(AdresWebSite), AdresWebSite);


                    }

                }

            }

            ReadNBP(tabAddress);

        }
        public void ComboBoxValue()
        {
            forCurrencyList.Items.Add("THB");
            forCurrencyList.Items.Add("USD");
            forCurrencyList.Items.Add("AUD");
            forCurrencyList.Items.Add("HKD");

            forCurrencyList.Items.Add("CAD");
            forCurrencyList.Items.Add("NZD");
            forCurrencyList.Items.Add("SGD");
            forCurrencyList.Items.Add("EUR");

            forCurrencyList.Items.Add("HUF");
            forCurrencyList.Items.Add("CHF");
            forCurrencyList.Items.Add("GBP");
            forCurrencyList.Items.Add("AUH");

            forCurrencyList.Items.Add("JPY");
            forCurrencyList.Items.Add("CZK");
            forCurrencyList.Items.Add("DKK");
            forCurrencyList.Items.Add("ISK");

            forCurrencyList.Items.Add("NOK");
            forCurrencyList.Items.Add("SEK");
            forCurrencyList.Items.Add("HRK");
            forCurrencyList.Items.Add("RON");

            forCurrencyList.Items.Add("BGN");
            forCurrencyList.Items.Add("TRY");
            forCurrencyList.Items.Add("ILS");
            forCurrencyList.Items.Add("CLP");

            forCurrencyList.Items.Add("PHP");
            forCurrencyList.Items.Add("MXN");
            forCurrencyList.Items.Add("ZAR");
            forCurrencyList.Items.Add("BRL");

            forCurrencyList.Items.Add("MYR");
            forCurrencyList.Items.Add("RUB");
            forCurrencyList.Items.Add("IDR");
            forCurrencyList.Items.Add("INR");

            forCurrencyList.Items.Add("KRW");
            forCurrencyList.Items.Add("CNY");
            forCurrencyList.Items.Add("XDR");


        }
        public void currencyValue(int count)
        {

            tabTHB[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(0).kurs_sredni.ToString()));
            tabUSD[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(1).kurs_sredni.ToString()));
            tabAUD[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(2).kurs_sredni.ToString()));
            tabHKD[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(3).kurs_sredni.ToString()));
            tabCAD[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(4).kurs_sredni.ToString()));
            tabNZD[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(5).kurs_sredni.ToString()));
            tabSGD[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(6).kurs_sredni.ToString()));
            tabEUR[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(7).kurs_sredni.ToString()));
            tabHUF[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(8).kurs_sredni.ToString()));
            tabCHF[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(9).kurs_sredni.ToString()));
            tabGBP[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(10).kurs_sredni.ToString()));
            tabUAH[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(11).kurs_sredni.ToString()));
            tabJPY[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(12).kurs_sredni.ToString()));
            tabCZK[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(13).kurs_sredni.ToString()));
            tabDKK[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(14).kurs_sredni.ToString()));
            tabISK[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(15).kurs_sredni.ToString()));
            tabNOK[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(16).kurs_sredni.ToString()));
            tabSEK[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(17).kurs_sredni.ToString()));
            tabHRK[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(18).kurs_sredni.ToString()));
            tabRON[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(19).kurs_sredni.ToString()));
            tabBGN[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(20).kurs_sredni.ToString()));
            tabTRY[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(21).kurs_sredni.ToString()));
            tabILS[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(22).kurs_sredni.ToString()));
            tabCLP[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(23).kurs_sredni.ToString()));
            tabPHP[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(24).kurs_sredni.ToString()));
            tabMXN[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(25).kurs_sredni.ToString()));
            tabZAR[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(26).kurs_sredni.ToString()));
            tabBRL[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(27).kurs_sredni.ToString()));
            tabMYR[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(28).kurs_sredni.ToString()));
            tabRUB[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(29).kurs_sredni.ToString()));
            tabIDR[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(30).kurs_sredni.ToString()));
            tabINR[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(31).kurs_sredni.ToString()));
            tabKRW[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(32).kurs_sredni.ToString()));
            tabCNY[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(33).kurs_sredni.ToString()));
            tabXDR[count] = Convert.ToDecimal(ChangingValue(CurrentCurs.ElementAt(34).kurs_sredni.ToString()));
        }
        async void ReadNBP(string[] time2)
        {
            string[] NBPdate = new string[7];


            Windows.Web.Http.HttpClient naszListonosz = new Windows.Web.Http.HttpClient();

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    NBPdate[i] = await naszListonosz.GetStringAsync(new Uri(time2[i]));
                }

            }
            catch (Exception )
            {
                //   MessageDialog dialError = new MessageDialog(ex.Message, "DANE: ");
                //   await dialError.ShowAsync();
                //   App.Current.Exit();

            }

            XDocument[] NBP = new XDocument[7];
            for (int i = 0; i < 7; i++)
            {
                NBP[i] = XDocument.Parse(NBPdate[i]);
            }


            ArrayPosition pozycjaTabeli = new ArrayPosition();
            XDocument DANE = NBP[0];
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                    DANE = NBP[i];
                else if (i == 1)
                    DANE = NBP[i];
                else if (i == 2)
                    DANE = NBP[i];
                else if (i == 3)
                    DANE = NBP[i];
                else if (i == 4)
                    DANE = NBP[i];
                else if (i == 5)
                    DANE = NBP[i];
                else if (i == 6)
                    DANE = NBP[i];
                CurrentCurs = (from item in DANE.Descendants("pozycja")
                                 select new ArrayPosition
                                 {

                                     kod_waluty = item.Element("kod_waluty").Value,


                                     kurs_sredni = item.Element("kurs_sredni").Value,

                                     przelicznik = item.Element("przelicznik").Value



                                 }).ToList();

                currencyValue(i);

            }


        }
        public bool IsValidUri(Uri uri, string zm)
        {

            using (HttpClient Client = new HttpClient())
            {

                HttpResponseMessage result = Client.GetAsync(uri).Result;
                HttpStatusCode StatusCode = result.StatusCode;

                switch (StatusCode)
                {

                    case HttpStatusCode.Accepted:
                        tabAddress[Counter] = zm;
                        Counter++;
                        return true;
                    case HttpStatusCode.OK:
                        tabAddress[Counter] = zm;
                        Counter++;
                        return true;
                    default:
                        return false;
                }
            }
        }
        private void loadChart()
        {

            List<Chart> lsSource = new List<Chart>();

            if (ComboBoxText == "THB")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i+1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabTHB[i] });
                }
             (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "USD")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabUSD[i] });
                }
             (column.Series[0] as ColumnSeries).ItemsSource = lsSource;
            }


            else if (ComboBoxText == "AUD")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabAUD[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "HKD")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabHKD[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "CAD")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabCAD[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "NZD")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabNZD[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "SGD")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabSGD[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "EUR")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabEUR[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "HUF")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabHUF[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "CHF")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabCHF[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "GBP")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabGBP[i] });
                }
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;
            }
            else if (ComboBoxText == "AUH")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabUAH[i] });
                }
        (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "JPY")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabJPY[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "CZK")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabCZK[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "DKK")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabDKK[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "ISK")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabISK[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "NOK")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabNOK[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "SEK")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabSEK[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "HRK")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabHRK[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "RON")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabRON[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "BGN")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabBGN[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "TRY")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabTRY[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "ILS")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabILS[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "CLP")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabCLP[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "PHP")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabPHP[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "MXN")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabMXN[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "ZAR")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabZAR[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "BRL")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabBRL[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "MYR")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabMYR[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "RUB")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabRUB[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "IDR")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabIDR[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "INR")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabINR[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "KRW")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabKRW[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "CNY")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabCNY[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }
            else if (ComboBoxText == "XDR")
            {
                for (int i = 0; i < 7; i++)
                {
                    string sre = "Publikacja" + (i + 1);
                    lsSource.Add(new Chart() { name = sre, Amount = (float)tabXDR[i] });
                }
       (column.Series[0] as ColumnSeries).ItemsSource = lsSource;

            }

        }

        public string ChangingValue(string word) => word.Replace(',', '.');

        private void ForCurrencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBoxText = forCurrencyList.SelectedItem.ToString();
            loadChart();
        }
        public class Chart
        {
            public string name { get; set; }
            public float Amount { get; set; }
        }

      
    }
}
