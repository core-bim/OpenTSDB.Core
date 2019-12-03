# OpenTSDB.Core
.NET Core  for OpenTSDB
#
Access opentsdb database based on .Net core. Almost all OpenTSDB features are accessiable via the API such as querying timeseries data, managing metadata and storing data points.

```C#
 class Test
    {
        OpenTsdbClient  apiClient = new OpenTsdbClient ();
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
            System.DateTime startTime = new System.DateTime(1970, 1, 1);
            return (int)(time - startTime).TotalSeconds;
        }
    }
    
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Init Api Url");
            ApiUrlConfig.ChangeBaseUrl("http://192.168.1.22:4242/");
           
            Test test = new Test();
            test.Run();
            Console.ReadKey();

        }

    }
