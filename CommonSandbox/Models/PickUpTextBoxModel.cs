using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonSandbox.Models.Enums;

namespace CommonSandbox.Models
{
    public class PickUpTextBoxModel
    {
        public string Title { get; private set; }
        public string Placeholder { get; private set; }
        public bool IsNecessarily { get; private set; }
        public FieldType Type { get; private set; }

        private PickUpTextBoxModel() { }

        public PickUpTextBoxModel(string title, string placeholder, bool isNecessarily, FieldType type) : this()
        {
            this.Title = title;
            this.Placeholder = placeholder;
            this.IsNecessarily = isNecessarily;
            this.Type = type;
        }
    }
}
