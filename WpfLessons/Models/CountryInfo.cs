using System.Collections.Generic;

namespace WpfLessons.Models
{
    internal class CountryInfo:PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceInfos { get; set; }
    }
}