using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FileEncryptor
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _contentViewModel = new PasswordInitializationViewModel(GoToOperations);
        }

        public void GoToOperations(string key)
        {
            ContentViewModel = new OperationsViewModel(key);
        }

        protected virtual void FirePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private object _contentViewModel;
        public object ContentViewModel
        {
            get => _contentViewModel;
            set
            {
                _contentViewModel = value;
                FirePropertyChanged();
            }
        }
    }
}