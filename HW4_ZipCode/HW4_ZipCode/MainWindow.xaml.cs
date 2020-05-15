using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HW4_ZipCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            uxSubmit.IsEnabled = false;
            TextBox textBox = sender as TextBox;
            string value = textBox.Text;

            if (USZipCode(value) || ExtendedUSZipCode(value) || CanadianPostalCode(value))
            {
                uxSubmit.IsEnabled = true;
            }

            e.Handled = true;
        }

        private bool USZipCode(string text)
        {
            return Regex.IsMatch(text, @"^\d{5}$");
        }

        private bool ExtendedUSZipCode(string text)
        {
            return Regex.IsMatch(text, @"^\d{5}-\d{4}$");
        }

        private bool CanadianPostalCode(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z]\d{1}[a-zA-Z]\d{1}[a-zA-Z]\d{1}$");
        }
    }
}
