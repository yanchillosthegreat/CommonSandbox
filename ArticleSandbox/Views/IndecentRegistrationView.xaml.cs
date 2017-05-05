using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ArticleSandbox.Views
{
    public sealed partial class IndecentRegistrationView : UserControl
    {
        private bool isUsernameValid = false;
        private bool isBirthdateValid = false;
        private bool isEmailValid = false;
        private bool isPasswordValid = false;

        public IndecentRegistrationView()
        {
            this.InitializeComponent();
            UpdateRegisterButton();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            isUsernameValid = ValidateText(textbox.Text, @".");
            UpdateRegisterButton();
        }

        private void BirthdateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            isBirthdateValid = ValidateText(textbox.Text, @"^\d{2}\.\d{2}\.\d{4}$");
            UpdateRegisterButton();
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            isEmailValid = ValidateText(textbox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$");
            UpdateRegisterButton();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            isPasswordValid = ValidateText(passwordBox.Password, @".");
            UpdateRegisterButton();
        }

        private bool ValidateText(string text, string regexPattern)
        {
            if (Regex.IsMatch(text, regexPattern))
            {
                return true;
            }
            return false;
        }

        private void UpdateRegisterButton()
        {
            if (isUsernameValid && isBirthdateValid && isEmailValid && isPasswordValid)
            {
                RegisterButton.IsEnabled = true;
            }
            else
            {
                RegisterButton.IsEnabled = false;
            }
        }
    }
}