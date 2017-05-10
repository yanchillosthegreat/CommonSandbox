using CommonSandbox.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSandbox.Services
{
    public class SidePanelService
    {
        public class SidePanelViewChangedArgs : EventArgs
        {
            public object View { get; private set; }

            public SidePanelViewChangedArgs(object view)
            {
                View = view;
            }
        }

        public enum SidePanelViewType
        {
            Search = 0,
            Registration = 1
        }

        public event EventHandler<SidePanelViewChangedArgs> ViewChanged;

        private static SidePanelService instance;
        public static SidePanelService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SidePanelService();
                }
                return instance;
            }
        }

        private SidePanelService()
        {

        }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            private set
            {
                currentView = value;
                ViewChanged?.Invoke(this, new SidePanelViewChangedArgs(value));
            }
        }

        public void SetView(SidePanelViewType type)
        {
            switch (type)
            {
                case SidePanelViewType.Search:
                    CurrentView = new SearchView();
                    break;
                case SidePanelViewType.Registration:
                    CurrentView = new RegistrationView();
                    break;
            }
        }
    }
}
