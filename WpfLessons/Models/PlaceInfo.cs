using System.Collections.Generic;
using System.Windows;

namespace WpfLessons.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Point { get; set; }
        public IEnumerable<ConfirmedCount> ConfirmedCounts { get; set; }
    }
}
