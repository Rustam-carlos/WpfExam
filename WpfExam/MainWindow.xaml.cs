using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace WpfExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string answer = string.Empty;
            WebClient client = new WebClient();



            string url = "https://" + "earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&starttime=2019-01-01&endtime=2019-01-02";

            using (Stream stream = client.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = reader.ReadToEnd();
                }
            }
            EarthQ.RootObject Robject = JsonConvert.DeserializeObject<EarthQ.RootObject>(answer);
            int count = Robject.metadata.count;

            

            List<EarthQ.Show> showall = new List<EarthQ.Show>();
            for (int i=0; i < count; i++)
            {
                showall.Add(new EarthQ.Show { mag = Robject.features[i].properties.mag, place = Robject.features[i].properties.place, time = Robject.features[i].properties.time, sig = Robject.features[i].properties.sig });
            }

            

            MyDataGrid.ItemsSource = showall;
        }
    }
}
