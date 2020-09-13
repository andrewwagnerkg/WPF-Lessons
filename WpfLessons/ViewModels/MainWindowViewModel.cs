using System;
using System.Collections.Generic;
using WpfLessons.ViewModels.Base;
using WpfLessons.Models;

namespace WpfLessons.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            var data_points=new List<DataPoint>((int)(360/0.1));
            for (var x = 0d; x <= 360; x+=0.1)
            {
                var to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);
                data_points.Add(new DataPoint{XValue = x, YValue = y});
            }

            TestData = data_points;
        }
        private string _Title="Test";
        public string Title { get=>_Title; set=>Set(ref _Title,value); }

        private string _Status="ОК";
        public string Status{get => _Status; set => Set(ref _Status, value);}

        private double _Progress;
        public double Progress { get=>_Progress; set=>Set(ref _Progress,value); }

        private IEnumerable<DataPoint> _TestData;
        public IEnumerable<DataPoint> TestData { get=>_TestData; set=>Set(ref _TestData,value); }
    }
}
