using ArticleSandbox.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSandbox.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private int counter;
        public int Counter
        {
            get { return counter; }
            set { Set(ref counter, value); }
        }

        public RelayCommand ButtonCommand { get; private set; }

        public MainPageViewModel()
        {
            ButtonCommand = new RelayCommand(
                () => Counter++
                );
        }
    }
}
