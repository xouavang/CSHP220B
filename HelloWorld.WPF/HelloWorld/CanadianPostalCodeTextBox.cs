using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace HelloWorld
{
    public class CanadianPostalCodeTextBox : TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {

            if (Text.Length < 6)
            {
                if (CaretIndex % 2 == 0)
                {
                    e.Handled = !IsAlphabetChar(e.Text);
                }
                else
                {
                    e.Handled = !IsNumericChar(e.Text);
                }
            }
            else
            {
                e.Handled = true;
            }
            
            base.OnPreviewTextInput(e);
        }


        private bool IsNumericChar(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsNumber(c)) return false;
            }

            return true;
        }

        private bool IsAlphabetChar(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c)) return false;
            }

            return true;
        }
    }
}
