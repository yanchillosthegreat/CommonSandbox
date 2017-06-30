using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace SharedViewModelApp.Controls
{
    [TemplateVisualState(Name = StateContentExpanded, GroupName = GroupContent)]
    [TemplateVisualState(Name = StateContentCollapsed, GroupName = GroupContent)]
    [TemplatePart(Name = ExpanderToggleButtonPart, Type = typeof(ToggleButton))]
    [ContentProperty(Name = "Content")]
    public partial class Expander : ContentControl
    {
        public const string GroupContent = "ExpandedStates";
        public const string StateContentExpanded = "Expanded";
        public const string StateContentCollapsed = "Collapsed";
        public const string ExpanderToggleButtonPart = "PART_ExpanderToggleButton";
        public const string MainContentPart = "PART_MainContent";

        public event EventHandler Expanded;
        public event EventHandler Collapsed;

        public Expander()
        {
            DefaultStyleKey = typeof(Expander);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (IsExpanded)
            {
                VisualStateManager.GoToState(this, StateContentExpanded, false);
            }
        }

        private void ExpandControl()
        {
            VisualStateManager.GoToState(this, StateContentExpanded, true);
            Expanded?.Invoke(this, new EventArgs());
        }

        private void CollapseControl()
        {
            VisualStateManager.GoToState(this, StateContentCollapsed, true);
            Collapsed?.Invoke(this, new EventArgs());
        }
    }
}
