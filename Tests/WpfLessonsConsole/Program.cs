using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfLessonsConsole
{
    static class Program
    {
        private const string DataUrl = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        public static async Task<Stream> GetDataStream()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(DataUrl, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        public static IEnumerable<string> GetDataLines()
        {
            using var dataStream = GetDataStream().Result;
            using var dataReader = new StreamReader(dataStream);
            while (!dataReader.EndOfStream)
            {
                var line = dataReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line;
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Country, string Province, int[]Count)> GetData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));
            foreach (var row in lines)
            {
                var Province = row[0].Trim();
                var Country = row[1].Trim(' ', '"').Trim(' ',',');
                var Count = row.Skip(5).Select(int.Parse).ToArray();
                yield return (Country, Province, Count);
            }
        }
        static void Main(string[] args)
        {

            var russia = GetData().First(v => v.Country .Equals("Russia", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(String.Join("\r\n",GetDates().Zip(russia.Count,(date,count)=>$"{date:yyyy-MM-dd} - {count}")));
            Console.ReadLine();
        }
    }
}
