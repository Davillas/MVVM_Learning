using System.Collections.Generic;

namespace MVVM_Learning.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
    }

}
