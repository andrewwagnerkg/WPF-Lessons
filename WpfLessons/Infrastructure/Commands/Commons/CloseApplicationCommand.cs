using System.Windows;
using WpfLessons.Infrastructure.Commands.Base;

namespace WpfLessons.Infrastructure.Commands.Commons
{

    internal class CloseApplicationCommand:BaseCommand
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
