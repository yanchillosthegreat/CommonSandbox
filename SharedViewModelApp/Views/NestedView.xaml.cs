using SharedViewModelApp.ViewModels;
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

namespace SharedViewModelApp.Views
{
    public sealed partial class NestedView : UserControl
    {
        public ParentViewModel ViewModel { get; private set; }

        public NestedView()
        {
            this.InitializeComponent();
            this.DataContextChanged += NestedView_DataContextChanged;
        }

        private void NestedView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            ViewModel = args.NewValue as ParentViewModel;
        }
    }
}
