using System;
using OpenTSDB.Core;
using OpenTSDB.Core.Models;
using OpenTSDB.Core.Extensions;
using System.Collections.Generic;

namespace OpenTSDBSample
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Init Api Url");
            ApiUrlConfig.ChangeBaseUrl("http://codebim.cn:4242/");
            ApiClient apiClient = new ApiClient();

            var list = new List<DataPoint<float>>();

            DataPoint<float> dataPoint = new DataPoint<float>();
            dataPoint.Metric = "bridge";
            dataPoint.Timestamp = ConvertDateTimeInt(DateTime.Now);
            dataPoint.Value = 23.4f;
            dataPoint.Tags.Add("dc", "lga");
            list.Add(dataPoint);
            await apiClient.PostAnonymousAsync("api/put?summary", dataPoint);


            Console.ReadKey();

        }

        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
