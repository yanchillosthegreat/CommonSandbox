using CommonSandbox.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSandbox.ViewModel
{
    public class SidePanelViewModel : BindableBase
    {
        public class SidePanelViewChangedEventArgs : EventArgs
        {
            public SidePanelViewType NewViewType { get; private set; }
            public SidePanelViewType OldViewType { get; private set; }

            public SidePanelViewChangedEventArgs(SidePanelViewType newType, SidePanelViewType oldType)
            {
                NewViewType = newType;
                OldViewType = oldType;
            }
        }

        public enum SidePanelViewType
        {
            None = 0,
            Search = 1,
            Registration = 2
        }

        public event EventHandler<SidePanelViewChangedEventArgs> SidePanelViewChanged;

        private SidePanelViewType currentViewType;
        public SidePanelViewType CurrentViewType
        {
            get { return currentViewType; }
            private set { Set(ref currentViewType, value); }
        }

        public SidePanelViewModel()
        {

        }

        public void SetView(SidePanelViewType newViewType)
        {
            var args = new SidePanelViewChangedEventArgs(newViewType, currentViewType);

            switch (newViewType)
            {
                case SidePanelViewType.Search:
                    CurrentViewType = SidePanelViewType.Search;
                    break;
                case SidePanelViewType.Registration:
                    CurrentViewType = SidePanelViewType.Registration;
                    break;
                default:
                    break;
            }

            SidePanelViewChanged?.Invoke(this, args);
        }
    }
}
