using CommonSandbox.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CommonSandbox.Views
{
    public sealed partial class SearchView : UserControl
    {
        public SidePanelViewModel ViewModel { get; private set; }

        public SearchView()
        {
            this.InitializeComponent();
            this.DataContextChanged += RegistrationView_DataContextChanged;
        }

        private void RegistrationView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            ViewModel = args.NewValue as SidePanelViewModel;
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel.SetView(SidePanelViewModel.SidePanelViewType.Registration);
        }
    }
}
