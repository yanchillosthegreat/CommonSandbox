using SharedViewModelApp.Models;
using SharedViewModelApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedViewModelApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public List<PickUpTextBoxModel> PickUpTextBoxModels { get; private set; }

        public MainPageViewModel()
        {
            this.PickUpTextBoxModels = new List<PickUpTextBoxModel>();
            this.PickUpTextBoxModels.Add(new PickUpTextBoxModel("Фамилия", "Иванов", true, FieldType.FIO));
            this.PickUpTextBoxModels.Add(new PickUpTextBoxModel("Отчество", "Иванович", false, FieldType.FIO));
        }
    }
}
