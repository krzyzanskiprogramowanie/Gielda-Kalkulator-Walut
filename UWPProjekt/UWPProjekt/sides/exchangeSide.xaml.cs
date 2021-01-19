using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPProjekt.sides
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class exchangeSide : Page
    {
        public exchangeSide()
        {
            this.InitializeComponent();
            Chart();
        }
        double[] Array = new double[7];
        public class ChartData
        {
            public string name { get; set; }
            public float Amount { get; set; }
        }
        private async void Chart()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17");
            string url = "https://info.bossa.pl/pub/metastock/mstock/sesjaall/sesjaall.prn?fbclid=IwAR3PleXV_9wev-ckEB3TBoa0ed5OXz_pDUiR8X49yzMgjPZPcHEFNsn0ad0";
            try
            {
                HttpResponseMessage response = await http.GetAsync(url);



                string allPrnText = await response.Content.ReadAsStringAsync();
                string ourValue = "";


                string[] ourValueArray = new string[7];
                for (int i = 0, j = 0, k = 0; i < 600; i++)
                {
                    if (allPrnText[i] == ',')
                    {
                        j++;
                        if (j == 7)
                        {

                            j = 0;
                            ourValueArray[k] = ourValue;
                            k++;
                            ourValue = "";
                            if (k == 7)
                                break;
                        }
                    }
                    ourValue += allPrnText[i];
                }




                int counter = 0;
                string HelpValue = "";
                string[] ourValueWithoutComma = new string[7];
                for (int i = 0; i < ourValueArray.Length; i++)
                {
                    string HelpWorth = ourValueArray[i];
                    for (int j = 0; j < HelpWorth.Length; j++)
                    {
                        if (i == 0)
                        {
                            if (HelpWorth[j] == ',')
                            {
                                counter++;

                            }
                            if (counter == 4)
                            {
                                HelpValue += HelpWorth[j];
                            }
                        }
                        else
                        {
                            if (HelpWorth[j] == ',')
                            {
                                counter++;

                            }
                            if (counter == 5)
                            {
                                HelpValue += HelpWorth[j];
                            }
                        }
                    }
                    ourValueWithoutComma[i] = HelpValue;
                    HelpValue = "";

                    counter = 0;

                }


                for (int i = 0; i < 7; i++)
                {
                    Array[i] = Convert.ToDouble(Changing(ourValueWithoutComma[i]));
                }


                loadChart();
            }
            catch (Exception)
            {
                Windows.UI.Popups.MessageDialog dlgError = new Windows.UI.Popups.MessageDialog("Brak Polaczenia z internetem", "DANE");
                await dlgError.ShowAsync();
            }
        }
        public string Changing(string word) => word.Replace(',', ' ');
        public void loadChart()
        {

            List<ChartData> lsSource = new List<ChartData>();




            lsSource.Add(new ChartData() { name = "F11BM19", Amount = (float)Array[0] });
            lsSource.Add(new ChartData() { name = "FACPM19", Amount = (float)Array[1] });
            lsSource.Add(new ChartData() { name = "FALRM19", Amount = (float)Array[2] });
            lsSource.Add(new ChartData() { name = "FATTM19", Amount = (float)Array[3] });
            lsSource.Add(new ChartData() { name = "FATTU19", Amount = (float)Array[4] });
            lsSource.Add(new ChartData() { name = "FCCCM19", Amount = (float)Array[5] });
            lsSource.Add(new ChartData() { name = "FCDRM19", Amount = (float)Array[6] });
            (column.Series[0] as ColumnSeries).ItemsSource = lsSource;


        }
    }
       
     
    
}
