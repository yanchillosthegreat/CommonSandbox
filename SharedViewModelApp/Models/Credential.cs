using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedViewModelApp.Models
{
    public class Credential : ValidatableBindableBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}
