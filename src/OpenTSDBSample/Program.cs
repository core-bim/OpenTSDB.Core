using System;
using OpenTSDB.Core;
using OpenTSDB.Core.Models;
using OpenTSDB.Core.Extensions;
using System.Collections.Generic;
using Flurl.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace OpenTSDBSample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Init Api Url");
            ApiUrlConfig.ChangeBaseUrl("http://192.168.1.12:4242/");
           
            Test test = new Test();
            test.Run();
            Console.ReadKey();

        }



    }

    class Test
    {
        ApiClient apiClient = new ApiClient();
        public async void Run()
        {
            var list = new List<DataPoint<float>>();
            DataPoint<float> dataPoint = new DataPoint<float>();
            dataPoint.Metric = "bridge";
            dataPoint.Timestamp = ConvertDateTimeInt(DateTime.Now);
            dataPoint.Value = 23.4f;
            dataPoint.Tags.Add("host", "YL-01-01");
            dataPoint.Tags.Add("dc", "lga");
            list.Add(dataPoint);

            var result = await apiClient.PostAsync<dynamic>("api/put?summary", list);
            Console.WriteLine(result);
        }

        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
