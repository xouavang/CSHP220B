using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for NumberControl.xaml
    /// </summary>
    public partial class NumberControl : UserControl
    {
        public NumberControl()
        {
            InitializeComponent();
        }

        public int Value
        {
            get;
            private set;
        }

        private void uxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Does not catch Pasting contents
            // To catch pasting contents, need to use TextBoxPasting event handler.
            // TextBox element must contain DataOjbect.Pasting.
            if (!IsValidNumber(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsValidNumber(string text)
        {
            foreach (var ch in text)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            int result;
            if (!int.TryParse(uxNumber.Text + text, out result))
            {
                return false;
            }

            Value = result;

            return true;
        }
    }
}
