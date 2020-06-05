using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LaptopLoanerApp.Models;

namespace LaptopLoanerApp
{
    /// <summary>
    /// Interaction logic for LoanerWindow.xaml
    /// </summary>
    public partial class LoanerWindow : Window
    {
        private List<ValidationError> _errors = new List<ValidationError>();
        public LoanerModel Loaner { get; set; }

        public LoanerWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!_errors.Any())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show(IncompleteFormMsg());
            }
        }

        private string IncompleteFormMsg()
        {
            StringBuilder errMsg = new StringBuilder("Please fill in required fields.\n\n");
            foreach (var validationError in _errors)
            {
                var bindingExpression = validationError.BindingInError as BindingExpression;
                errMsg.Append(' ', 7).Append("\u2022 ").AppendLine(bindingExpression.ResolvedSourcePropertyName);
            }
            return errMsg.ToString();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Loaner != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Loaner = new LoanerModel();
                Loaner.CreatedDate = DateTime.Now;
            }

            uxDockPanel.DataContext = Loaner;
        }

        private void uxStudentId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Validation_OnError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                _errors.Add(e.Error);
            }
            else
            {
                _errors.Remove(e.Error);
            }
        }
    }
}
