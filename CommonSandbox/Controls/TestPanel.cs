using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CommonSandbox.Controls
{
    public sealed class TestPanel : ContentControl
    {
        private Rectangle rect;
        private bool _useTransitions = false;
        private VisualState _collapsedState;

        public static readonly DependencyProperty HeaderContentProperty = DependencyProperty.Register("HeaderContent",
            typeof(object), typeof(TestPanel), null);

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded",
            typeof(bool), typeof(TestPanel), new PropertyMetadata(false));

        public object HeaderContent
        {
            get { return GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        public TestPanel()
        {
            this.DefaultStyleKey = typeof(TestPanel);
        }

        private void СhangeVisualState(bool useTransitions)
        {
            //if (IsExpanded)
            //{
            //    if (contentElement != null)
            //    {
            //        contentElement.Visibility = Visibility.Visible;
            //    }
            //    VisualStateManager.GoToState(this, "Expanded", useTransitions);
            //}
            //else
            //{
            //    VisualStateManager.GoToState(this, "Collapsed", useTransitions);
            //    _collapsedState = (VisualState)GetTemplateChild("Collapsed");
            //    if (_collapsedState == null)
            //    {
            //        if (contentElement != null)
            //        {
            //            contentElement.Visibility = Visibility.Collapsed;
            //            contentElement.UpdateLayout();
            //        }
            //    }
            //}
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //toggleExpander = (ToggleButton)GetTemplateChild("ExpandCollapseButton");
            //if (toggleExpander != null)
            //{
            //    toggleExpander.Click += (object sender, RoutedEventArgs e) =>
            //    {
            //        IsExpanded = !IsExpanded;
            //        toggleExpander.IsChecked = IsExpanded;
            //        СhangeVisualState(_useTransitions);
            //    };
            //}

            //contentElement = (FrameworkElement)GetTemplateChild("Content");
            //if (contentElement != null)
            //{
            //    _collapsedState = (VisualState)GetTemplateChild("Collapsed");
            //    if ((_collapsedState != null) && (_collapsedState.Storyboard != null))
            //    {
            //        _collapsedState.Storyboard.Completed += (object sender, object e) =>
            //        {
            //            contentElement.Visibility = Visibility.Collapsed;
            //        };
            //    }
            //}

            rect = (Rectangle)GetTemplateChild("rect");
            if (rect != null)
            {
                rect.Tapped += (object sender, TappedRoutedEventArgs e) =>
                {
                    IsExpanded = !IsExpanded;
                    //rect.IsChecked = IsExpanded;
                    СhangeVisualState(_useTransitions);
                };
            }

            СhangeVisualState(false);
        }
    }
}
