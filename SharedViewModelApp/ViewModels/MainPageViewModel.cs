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
            this.PickUpTextBoxModels.Add(new PickUpTextBoxModel("Имя", "Иванов", true, FieldType.FIO));
            this.PickUpTextBoxModels.Add(new PickUpTextBoxModel("Телефон", "+79001234567", true, FieldType.Phone));
            this.PickUpTextBoxModels.Add(new PickUpTextBoxModel("E-mail", "example@example.ru", false, FieldType.Email));
        }
    }
}
