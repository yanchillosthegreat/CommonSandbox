using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace CommonSandbox.Controls
{
    public enum ScrollHeaderMode
    {
        None,
        QuickReturn,
        Sticky,
        Fade
    }

    public class ScrollHeader : ContentControl
    {
        public ScrollHeader()
        {
            this.DefaultStyleKey = typeof(ScrollHeader);
            HorizontalContentAlignment = HorizontalAlignment.Stretch;
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(nameof(Mode), typeof(ScrollHeaderMode), typeof(ScrollHeader), new PropertyMetadata(ScrollHeaderMode.None, OnModeChanged));

        public ScrollHeaderMode Mode
        {
            get { return (ScrollHeaderMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ScrollHeader)?.UpdateScrollHeaderBehavior();
        }

        private void UpdateScrollHeaderBehavior()
        {
            if (TargetListViewBase == null)
            {
                return;
            }

            foreach (var behavior in Interaction.GetBehaviors(TargetListViewBase))
            {
                if (behavior is FadeHeaderBehavior || behavior is QuickReturnHeaderBehavior || behavior is StickyHeaderBehavior)
                {
                    Interaction.GetBehaviors(TargetListViewBase).Remove(behavior);
                }
            }

            switch (Mode)
            {
                case ScrollHeaderMode.None:
                    break;
                case ScrollHeaderMode.QuickReturn:
                    Interaction.GetBehaviors(TargetListViewBase).Add(new QuickReturnHeaderBehavior());
                    break;
                case ScrollHeaderMode.Sticky:
                    Interaction.GetBehaviors(TargetListViewBase).Add(new StickyHeaderBehavior());
                    break;
                case ScrollHeaderMode.Fade:
                    Interaction.GetBehaviors(TargetListViewBase).Add(new FadeHeaderBehavior());
                    break;
            }
        }
    }
}
