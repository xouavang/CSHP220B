using LaptopLoanerApp.Models;
using LaptopLoanerApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LaptopLoanerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoanerModel selectedLoaner;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public MainWindow()
        {
            InitializeComponent();
            LoadLoaners();
        }

        private void uxNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new LoanerWindow();
            if (window.ShowDialog() == true)
            {
                var uiLoanerModel = window.Loaner;
                var repositoryLoanerModel = uiLoanerModel.ToRepositoryModel();
                App.LaptopLoanerRepository.Add(repositoryLoanerModel);
                LoadLoaners();
            }
        }

        private void LoadLoaners()
        {
            var loaners = App.LaptopLoanerRepository.GetAll();

            uxLoanerList.ItemsSource = loaners.Select(t => LoanerModel.ToModel(t)).ToList();
        }

        private void ModifyLoaner()
        {
            if (selectedLoaner == null)
            {
                return;
            }

            var window = new LoanerWindow();
            window.Loaner = selectedLoaner.Clone();

            if (window.ShowDialog() == true)
            {
                App.LaptopLoanerRepository.Update(window.Loaner.ToRepositoryModel());
                LoadLoaners();
            }
        }

        private void uxModify_Click(object sender, RoutedEventArgs e)
        {
            ModifyLoaner();
        }

        private void uxDelete_Click(object sender, RoutedEventArgs e)
        {
            App.LaptopLoanerRepository.Remove(selectedLoaner.Id);
            selectedLoaner = null;
            LoadLoaners();
        }

        private void uxLoanerListColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxLoanerList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
            {
                newDir = ListSortDirection.Descending;
            }

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxLoanerList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void uxLoanerLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLoaner = (LoanerModel)uxLoanerList.SelectedValue;
        }

        private void uxLoanerLists_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ModifyLoaner();
        }
    }
}
