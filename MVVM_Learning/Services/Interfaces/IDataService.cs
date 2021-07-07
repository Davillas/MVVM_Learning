using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.Models;

namespace MVVM_Learning.Services.Interfaces
{
    internal interface IDataService
    {
        IEnumerable<CountryInfo> GetData();
    }
}
