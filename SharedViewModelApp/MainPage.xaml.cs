using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SharedViewModelApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //private void ShowButton_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Storyboard sb = new Storyboard();
        //    DoubleAnimation da = new DoubleAnimation
        //    {
        //        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 350)),
        //        From = 0,
        //        To = 200,
        //        EasingFunction = new ExponentialEase() { Exponent = 5 },
        //        EnableDependentAnimation = true
        //    };

        //    Storyboard.SetTarget(da, ContentGrid);
        //    Storyboard.SetTargetProperty(da, nameof(Height));

        //    sb.Children.Add(da);
        //    sb.Begin();
        //}

        //private void HideButton_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Storyboard sb = new Storyboard();
        //    DoubleAnimation da = new DoubleAnimation
        //    {
        //        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 350)),
        //        From = 200,
        //        To = 0,
        //        EasingFunction = new ExponentialEase() { Exponent = 5 },
        //        EnableDependentAnimation = true
        //    };

        //    Storyboard.SetTarget(da, ContentGrid);
        //    Storyboard.SetTargetProperty(da, nameof(Height));

        //    sb.Children.Add(da);
        //    sb.Begin();
        //}
    }
}
