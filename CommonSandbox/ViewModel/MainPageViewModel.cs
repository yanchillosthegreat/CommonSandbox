using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonSandbox.Models;
using CommonSandbox.Models.Enums;

namespace CommonSandbox.ViewModel
{
    public class MainPageViewModel
    {
        public List<PickUpTextBoxModel> PickUpTextBoxModels { get; private set; }

        public MainPageViewModel()
        {
            this.PickUpTextBoxModels = new List<PickUpTextBoxModel>
            {
                new PickUpTextBoxModel("Фамилия", "Иванов", true, FieldType.FIO),
                new PickUpTextBoxModel("Отчество", "Иванович", false, FieldType.FIO),
                new PickUpTextBoxModel("Телефон", "+79831045403", true, FieldType.Phone),
                new PickUpTextBoxModel("E-mail", "example@example.ru", false, FieldType.Email)
            };
        }
    }
}
