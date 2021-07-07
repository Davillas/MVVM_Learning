using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Learning.Models;
using MVVM_Learning.Services.Interfaces;

namespace MVVM_Learning.Services
{
    internal class DataService : IDataService
    {
        private const string _DataSourceAddress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        public DataService()
        {
            
        }
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_DataSourceAddress, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = (SynchronizationContext.Current is null ? GetDataStream() : Task.Run(GetDataStream)).Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line
                    .Replace("Korea,", "Korea -")
                    .Replace("Bonaire,", "Bonaire -")
                    .Replace("Repatriated Travellers", "Repatriated")
                    .Replace("Saint Helena," , "Saint Helena -");
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Province, string Country, (double Lat, double Long) Place, int[] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
                .Skip(1).Select(line => line.Split(','));

            foreach (var row in lines)
            {
                if (row[0].Trim() == "Repatriated" || row[0].Trim() == "Unknown") continue;

                    

                var province = row[0].Trim();
                var countryName = row[1].Trim(' ', '"');
                var latitude = double.Parse(row[2]);
                var longitude = double.Parse(row[3]);
                var counts = row.Skip(4).Select(int.Parse).ToArray();

                yield return (province, countryName, (latitude, longitude), counts);
            }
        }

        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();

            var data = GetCountriesData().GroupBy(d => d.Country);

            foreach (var countryInfo in data)
            {
                var country = new CountryInfo()
                {
                    Name = countryInfo.Key,
                    ProvinceCounts = countryInfo.Select(c => new PlaceInfo
                    {
                        Name = c.Province,
                        Location = new Point(c.Place.Lat, c.Place.Long),
                        Counts = dates.Zip(c.Counts, (date, count) => new ConfirmedCount{ Date = date, Count = count})
                    })
                };
                yield return country;
            }
                


            
        }
    }
}
