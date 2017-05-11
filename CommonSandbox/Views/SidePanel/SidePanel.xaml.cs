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
using static CommonSandbox.ViewModel.SidePanelViewModel;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CommonSandbox.Views
{
    public sealed partial class SidePanel : UserControl
    {
        public SidePanelViewModel ViewModel { get; private set; }

        public SidePanel()
        {
            this.InitializeComponent();
            ViewModel = new SidePanelViewModel();
            ViewModel.SidePanelViewChanged += ViewModel_SidePanelViewChanged;
            ViewModel.SetView(SidePanelViewType.Search);
        }

        private void WidthAnimation(SidePanelViewType newViewType, SidePanelViewType oldViewType)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.35)),
                EnableDependentAnimation = true
            };

            switch (newViewType)
            {
                case SidePanelViewType.Search:
                    switch (oldViewType)
                    {
                        case SidePanelViewType.None:
                            da.From = 0;
                            da.To = contentControl.MinWidth;
                            break;
                        case SidePanelViewType.Registration:
                            da.From = this.Width;
                            da.To = contentControl.MinWidth;
                            break;
                        default:
                            break;
                    }
                    break;
                case SidePanelViewType.Registration:
                    switch (oldViewType)
                    {
                        case SidePanelViewType.Search:
                            da.From = contentControl.MinWidth;
                            da.To = contentControl.MaxWidth;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            Storyboard.SetTargetProperty(da, nameof(Width));
            Storyboard.SetTarget(da, this);
            sb.Children.Add(da);
            sb.Begin();
        }

        private void ContentControl_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > -(contentControl.MaxWidth / 2))
            {
                this.Width = contentControl.MaxWidth;
            }
        }

        private void ViewModel_SidePanelViewChanged(object sender, SidePanelViewChangedEventArgs e)
        {
            contentControl.ManipulationCompleted -= ContentControl_ManipulationCompleted;
            contentControl.ManipulationDelta -= ContentControl_ManipulationDelta;

            switch (e.NewViewType)
            {
                case SidePanelViewType.Search:
                    contentControl.Content = new SearchView();
                    contentControl.ManipulationMode = ManipulationModes.None;
                    break;
                case SidePanelViewType.Registration:
                    contentControl.Content = new RegistrationView();
                    contentControl.ManipulationMode = ManipulationModes.TranslateX;
                    contentControl.ManipulationCompleted += ContentControl_ManipulationCompleted;
                    contentControl.ManipulationDelta += ContentControl_ManipulationDelta;
                    break;
                default:
                    break;
            }

            WidthAnimation(e.NewViewType, e.OldViewType);
        }

        private void ContentControl_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                this.Width += e.Delta.Translation.X;
            }

            if (e.Cumulative.Translation.X < -(contentControl.MaxWidth / 2) || e.Delta.Translation.X < -5)
            {
                switch (ViewModel.CurrentViewType)
                {
                    case SidePanelViewType.Registration:
                        ViewModel.SetView(SidePanelViewType.Search);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}