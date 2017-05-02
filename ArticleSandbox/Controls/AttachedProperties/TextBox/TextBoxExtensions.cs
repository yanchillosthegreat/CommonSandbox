using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ArticleSandbox.Controls.AttachedProperties
{
    public class TextBoxExtensions
    {
        public static string GetRegexPattern(DependencyObject obj)
        {
            return (string)obj.GetValue(RegexPatternProperty);
        }

        public static void SetRegexPattern(DependencyObject obj, string value)
        {
            obj.SetValue(RegexPatternProperty, value);
        }

        public static readonly DependencyProperty RegexPatternProperty =
            DependencyProperty.RegisterAttached("RegexPattern", typeof(string), typeof(TextBoxExtensions), new PropertyMetadata(string.Empty, OnRegexPatternChanged));

        public static bool GetIsValid(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsValidProperty);
        }

        public static void SetIsValid(DependencyObject obj, bool value)
        {
            obj.SetValue(IsValidProperty, value);
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.RegisterAttached("IsValid", typeof(bool), typeof(TextBoxExtensions), new PropertyMetadata(true));

        private static void OnRegexPatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as TextBox;
            if (textbox == null)
            {
                return;
            }

            textbox.TextChanged -= Textbox_TextChanged;

            var regexPattern = (string)e.NewValue;

            if (string.IsNullOrEmpty(regexPattern))
            {
                return;
            }

            textbox.TextChanged += Textbox_TextChanged;
            SetIsValid(textbox, ValidateText(textbox.Text, regexPattern));
        }

        private static void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox == null)
            {
                return;
            }

            if (ValidateText(textbox.Text, GetRegexPattern(textbox)))
            {
                SetIsValid(textbox, true);
            }
            else
            {
                SetIsValid(textbox, false);
            }
        }

        private static bool ValidateText(string text, string regexPattern)
        {
            if (Regex.IsMatch(text, regexPattern))
            {
                return true;
            }
            return false;
        }
    }
}
