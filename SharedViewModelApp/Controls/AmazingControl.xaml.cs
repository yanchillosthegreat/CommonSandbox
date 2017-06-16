using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SharedViewModelApp.Controls
{
    public sealed partial class AmazingControl : UserControl
    {
        private ScrollViewer headerScrollViewer;
        private ScrollViewer bodyScrollViewer;

        public AmazingControl()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            headerScrollViewer = header.GetFirstDescendantOfType<ScrollViewer>();
            bodyScrollViewer = body.GetFirstDescendantOfType<ScrollViewer>();

            headerScrollViewer.ViewChanged += HeaderScrollViewer_ViewChanged;
        }

        private void HeaderScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            //bodyScrollViewer.ChangeView(headerScrollViewer.HorizontalOffset, null, null);
            bodyScrollViewer.ScrollToHorizontalOffset(headerScrollViewer.HorizontalOffset);
        }
    }
}
