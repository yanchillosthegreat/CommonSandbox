using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CommonSandbox.Models.Enums;

namespace CommonSandbox.Controls
{
    public sealed class PickUpTextBox : TextBox
    {
        private const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$";
        private const string PhoneNumberRegex = @"^(\+7|8)\d{10}$";
        private const string FIOReges = @"^[а-яА-ЯёЁa-zA-Z\-]+$";

        private TextBlock _necessityIndicatorTextBlock;

        public bool IsNecessarily
        {
            get => (bool)GetValue(IsNecessarilyProperty);
            set => SetValue(IsNecessarilyProperty, value);
        }

        public static readonly DependencyProperty IsNecessarilyProperty =
            DependencyProperty.Register("IsNecessarily", typeof(bool), typeof(PickUpTextBox), new PropertyMetadata(false, IsNecessarilyPropertyChanged));

        private static void IsNecessarilyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as PickUpTextBox;
            if (textbox == null || !(e.NewValue is bool))
            {
                return;
            }

            textbox.UpdateNecessityIndicator();
        }

        public FieldType FieldType
        {
            get => (FieldType)GetValue(FieldTypeProperty);
            set => SetValue(FieldTypeProperty, value);
        }

        public static readonly DependencyProperty FieldTypeProperty =
            DependencyProperty.Register("FieldType", typeof(FieldType), typeof(PickUpTextBox), new PropertyMetadata(FieldType.FIO));

        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set => SetValue(ErrorMessageProperty, value);
        }

        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(PickUpTextBox), new PropertyMetadata(string.Empty));

        public PickUpTextBox()
        {
            DefaultStyleKey = typeof(PickUpTextBox);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _necessityIndicatorTextBlock = GetTemplateChild("NecessityIndicatorTextBlock") as TextBlock;

            TextChanged += OnTextChanged;

            UpdateControl();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var textbox = sender as PickUpTextBox;
            if (textbox == null)
            {
                return;
            }

            if (textbox.Text.Length == 0)
            {
                VisualStateManager.GoToState(this, "Indeterminate", true);
                return;
            }

            VisualStateManager.GoToState(this, ValidateText(textbox.Text) ? "Valid" : "Invalid", true);
        }

        private bool ValidateText(string text)
        {
            switch (FieldType)
            {
                case FieldType.FIO:
                    return Regex.IsMatch(text, FIOReges);
                case FieldType.Phone:
                    return Regex.IsMatch(text, PhoneNumberRegex);
                case FieldType.Email:
                    return Regex.IsMatch(text, EmailRegex);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateControl()
        {
            UpdateNecessityIndicator();
        }

        private void UpdateNecessityIndicator()
        {
            if (_necessityIndicatorTextBlock != null)
            {
                _necessityIndicatorTextBlock.Visibility = IsNecessarily ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
