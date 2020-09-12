using WpfLessons.ViewModels.Base;

namespace WpfLessons.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title="Test";
        public string Title { get=>_Title; set=>Set(ref _Title,value); }

        private string _Status;
        public string Status{get => _Status; set => Set(ref _Status, value);}

        private double _Progress;
        public double Propgress { get=>_Progress; set=>Set(ref _Progress,value); }

    }
}
