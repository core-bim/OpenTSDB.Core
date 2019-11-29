using System;
using OpenTSDB.Core;
using OpenTSDB.Core.Models;
using OpenTSDB.Core.Extensions;
using System.Collections.Generic;
using Flurl.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using OpenTSDB.Core.Models.Rollup;
using OpenTSDB.Core.Models.Histogram;

namespace OpenTSDBSample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Init Api Url");
            ApiUrlConfig.ChangeBaseUrl("http://codebim.cn:4242/");
           
            Test test = new Test();
          //  test.Put();
           test.histogram();
            Console.ReadKey();
        }

    }

    class Test
    {
        OpenTsdbClient apiClient = new OpenTsdbClient();
        public async void Put()
        {
            
            var list = new List<DataPoint<float>>();
            for(int i = 0; i<= 50; i++)
            {
                float value = (float)new Random().NextDouble();
                DataPoint<float> dataPoint = new DataPoint<float>();
                dataPoint.Metric = "bridge";
                dataPoint.Timestamp = ConvertDateTimeInt(DateTime.Now.AddHours(1));
                dataPoint.Value = value;
                dataPoint.Tags.Add("host", "YL-01-01");
                dataPoint.Tags.Add("dc", "lga");
                list.Add(dataPoint);
            }
           

          //  var result = await apiClient.PostAsync<dynamic>("api/put?summary", list);


            var result2 = await apiClient.PostAsync<dynamic>("/api/put/?details&sync&sync_timeout=60000", list);
            if (result2 != null)
            {
                Console.WriteLine(result2);
            }
          
        }

        public async void Rollup()
        {
           
            RollupRequest<float> dataPoint = new RollupRequest<float>();
            dataPoint.Metric = "bridge";
            dataPoint.Timestamp = 1575022650;
            dataPoint.Value = 23.4f;
            dataPoint.Tags.Add("host", "YL-01-01");
            dataPoint.Tags.Add("dc", "lga");
            //dataPoint.Interval = "1h";
            //dataPoint.Aggregator= "SUM";
            //dataPoint.GroupByAggregator = "SUM";
            var result = await apiClient.PostAsync<dynamic>("/api/rollup?summary", dataPoint);
            Console.WriteLine(result);
        }

        public async void histogram()
        {
            HistogramRequest dataPoint = new HistogramRequest();
            dataPoint.Metric = "bridge";
            dataPoint.Timestamp = ConvertDateTimeInt(DateTime.Now);
            dataPoint.Overflow = 1;
            dataPoint.Underflow = 0;
            dataPoint.Buckets = new Dictionary<string, int>()
            {
                { "0,1.75", 12 }, {"1.75,3.5", 16 }
            };
            dataPoint.Tags.Add("host", "YL-01-01");
            dataPoint.Tags.Add("dc", "lga");

            var result = await apiClient.PostAsync<dynamic>("/api/put?details", dataPoint);
            Console.WriteLine(result);
        }

        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
