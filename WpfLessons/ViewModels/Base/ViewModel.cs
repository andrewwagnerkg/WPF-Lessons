using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfLessons.Annotations;
using WpfLessons.Infrastructure.Commands.Commons;

namespace WpfLessons.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        protected ViewModel()
        {
            CloseApplicationCommand = new CloseApplicationCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(item, value)) return false;
            item = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public ICommand CloseApplicationCommand { get; set; }


    }
}
