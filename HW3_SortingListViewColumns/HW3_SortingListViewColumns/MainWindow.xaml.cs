// Vang, Xoua
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;

namespace HW3_SortingListViewColumns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>
            {
                new Models.User { Name = "Dave", Password = "1DavePwd" },
                new Models.User { Name = "Steve", Password = "2StevePwd" },
                new Models.User { Name = "Lisa", Password = "3LisaPwd" }
            };

            uxList.ItemsSource = users;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var obj = sender as GridViewColumnHeader;
            string sortBy = obj.Tag.ToString();

            uxList.Items.SortDescriptions.Clear();
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
        }
    }
}
