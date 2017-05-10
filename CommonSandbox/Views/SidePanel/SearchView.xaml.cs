using CommonSandbox.Services;
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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CommonSandbox.Views
{
    public sealed partial class SearchView : UserControl
    {
        private SidePanelService sidePanelService;

        public SearchView()
        {
            this.InitializeComponent();
            sidePanelService = SidePanelService.Instance;
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            sidePanelService.SetView(SidePanelService.SidePanelViewType.Registration);
        }
    }
}
