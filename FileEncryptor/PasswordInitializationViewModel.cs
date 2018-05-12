using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace FileEncryptor
{
    public class PasswordInitializationViewModel 
    {

        public PasswordInitializationViewModel(Action<string> enterAction)
        {
            EnterCommand = new DelegateCommand(() =>{ enterAction.Invoke(Key);}, () => !string.IsNullOrEmpty(Key));
        }

        private string _key;

        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                EnterCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand EnterCommand { get; set; }
    }
}
