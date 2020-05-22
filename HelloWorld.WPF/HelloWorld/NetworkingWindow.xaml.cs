using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for NetworkingWindow.xaml
    /// </summary>
    public partial class NetworkingWindow : Window
    {
        private WeatherService weatherService;

        public NetworkingWindow()
        {
            InitializeComponent();

            weatherService = new WeatherService();

            var weatherModel = weatherService.GetWeather();

            MessageBox.Show(weatherModel.weather.First().main);

            
        }
    }
}
