using CommonSandbox.Views;
using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace CommonSandbox.Controls.Behaviors
{
    public class ClientPanelViewSlideBehavior : Behavior<ClientPanelView>
    {
        private Point startPosition;
        private double delta = 50;

        public double MinWidth { get; set; }
        public double MaxWidth { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.TranslateX;
            AssociatedObject.ManipulationStarted += AssociatedObject_ManipulationStarted;
            AssociatedObject.ManipulationCompleted += AssociatedObject_ManipulationCompleted;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.System;
            AssociatedObject.ManipulationStarted -= AssociatedObject_ManipulationStarted;
            AssociatedObject.ManipulationCompleted -= AssociatedObject_ManipulationCompleted;
        }

        private void AssociatedObject_ManipulationStarted(object sender, Windows.UI.Xaml.Input.ManipulationStartedRoutedEventArgs e)
        {
            startPosition = e.Position;
            AssociatedObject.ManipulationDelta += AssociatedObject_ManipulationDelta;
        }

        private void AssociatedObject_ManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {
            startPosition = default(Point);
            AssociatedObject.ManipulationDelta -= AssociatedObject_ManipulationDelta;
        }

        private void AssociatedObject_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            var clientPanelView = sender as ClientPanelView;

            if (e.Position.X - startPosition.X > delta)
            {
                AssociatedObject.ManipulationDelta -= AssociatedObject_ManipulationDelta;
                Storyboard sb = new Storyboard();
                DoubleAnimation da = new DoubleAnimation
                {
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    From = 256,
                    To = 400
                };
                Storyboard.SetTargetProperty(da, "(FrameworkElement.Width)");
                Storyboard.SetTarget(da, clientPanelView);
                sb.Children.Add(da);
                sb.Begin();
                return;
            }
            if (startPosition.X - e.Position.X > delta)
            {
                Storyboard sb = new Storyboard();
                DoubleAnimation da = new DoubleAnimation
                {
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    From = 400,
                    To = 256
                };
                Storyboard.SetTargetProperty(da, "(UIElement.Width)");
                Storyboard.SetTarget(da, clientPanelView);
                sb.Children.Add(da);
                sb.Begin();
                return;
            }
        }
    }
}
