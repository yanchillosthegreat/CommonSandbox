using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ArticleSandbox.Controls.AP
{
    public class TextBoxExtension
    {
        public static string GetRegex(DependencyObject obj)
        {
            return (string)obj.GetValue(RegexProperty);
        }

        public static void SetRegex(DependencyObject obj, string value)
        {
            obj.SetValue(RegexProperty, value);
        }

        public static readonly DependencyProperty RegexProperty = DependencyProperty.RegisterAttached(
            "Regex", typeof(string), typeof(TextBoxExtension), new PropertyMetadata(string.Empty, RegexChanged));

        private static void RegexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;

            if (textBox == null)
                return;

            var regex = e.NewValue as string;

            if (string.IsNullOrEmpty(regex))
            {
                textBox.TextChanged -= TextBox_TextChanged;
            }
            else
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (!Regex.IsMatch(textBox.Text, "^[a-zA-Z]*$"))
            {

            }
        }

        //private static TextChangedEventHandler handler = (s, e) =>
        //{
        //    TextBox textBox = s as TextBox;
        //    if (!Regex.IsMatch(textBox.Text, "^[a-zA-Z]*$"))
        //    {
        //        textBox.BorderBrush = new SolidColorBrush(Colors.Red);
        //    }
        //    else
        //    {
        //        textBox.BorderBrush = Application.Current.Resources["SystemControlForegroundChromeDisabledLowBrush"] as Brush;
        //    }
        //};

        //private static void AllowOnlyStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is TextBox textBox)
        //    {

        //    }
        //}
    }
}
