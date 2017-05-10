using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedViewModelApp.ViewModels
{
    public class ParentViewModel
    {
        public string SomeText { get; set; }

        public ParentViewModel()
        {
            SomeText = "Some Text";
        }
    }
}
