using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ListBoxWindow.xaml
    /// </summary>
    public partial class ListBoxWindow : Window
    {
        public ListBoxWindow()
        {
            InitializeComponent();

            // We could load from the database
            // OR we could use an in memory collection
            var users = new ObservableCollection<Models.User>
            {
                new Models.User { Name = "Steve" },
                new Models.User { Name = "Lisa" },
                new Models.User { Name = "Dave" },
                new Models.User { Name = "Mike" },
                new Models.User { Name = "Susan" }
            };

            uxCurrentList.ItemsSource = users;

            // Set uxRemoveList to an empty list
            users = new ObservableCollection<Models.User>();
            uxRemoveList.ItemsSource = users;
        }

        private void uxDelete_Click(object sender, RoutedEventArgs e)
        {
            uxDelete.IsEnabled = false;

            // Get the current selected user
            var user = (Models.User)uxCurrentList.SelectedValue;

            // Remove the user from the list
            var list = (ObservableCollection<Models.User>)uxCurrentList.ItemsSource;
            list.Remove(user);

            // Add the user to the other list
            list = (ObservableCollection<Models.User>)uxRemoveList.ItemsSource;
            list.Add(user);
        }

        private void uxRemove_Click(object sender, RoutedEventArgs e)
        {
            uxRemove.IsEnabled = false;

            var user = (Models.User)uxRemoveList.SelectedValue;
            var list = (ObservableCollection<Models.User>)uxRemoveList.ItemsSource;
            list.Remove(user);

            list = (ObservableCollection<Models.User>)uxCurrentList.ItemsSource;
            list.Add(user);
        }

        private void uxCurrentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Only enable the Delete button if we are selecting items (AddedItems)
            uxDelete.IsEnabled = (e.AddedItems.Count > 0);
        }

        private void uxRemoveList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxRemove.IsEnabled = (e.AddedItems.Count > 0);
        }

        private void uxApply_Click(object sender, RoutedEventArgs e)
        {
            // Loop through the uesrs in the remove list and "process them"
            foreach (Models.User user in uxRemoveList.Items)
            {
                MessageBox.Show("Removing item: " + user.Name);
            }
        }
    }
}
