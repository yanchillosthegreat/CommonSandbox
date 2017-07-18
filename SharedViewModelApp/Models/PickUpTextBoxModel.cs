using SharedViewModelApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedViewModelApp.Models
{
    public class PickUpTextBoxModel
    {
        public string Title { get; private set; }
        public string Placeholder { get; private set; }
        public bool IsNecessarily { get; private set; }
        public FieldType Type { get; set; }

        private PickUpTextBoxModel() { }

        public PickUpTextBoxModel(string Title, string Placeholder, bool IsNecessarily, FieldType Type) : this()
        {
            this.Title = Title;
            this.Placeholder = Placeholder;
            this.IsNecessarily = IsNecessarily;
            this.Type = Type;
        }
    }
}
