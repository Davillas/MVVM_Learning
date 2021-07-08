using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MVVM_Learning.Services
{
    internal class AsyncDataService : IAsyncDataService
    {
        
        private const int __SleepTime = 7000;
        public string GetResult(DateTime Time)
        {
            Thread.Sleep(__SleepTime);
            return $"Result is: {Time}";
        }
    }
}
