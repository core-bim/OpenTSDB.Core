using System.Collections.Generic;

namespace OpenTSDB.Core.Models
{

    public class Tags : Dictionary<string, string>
    {
         const string _host = "host";
        public static Tags Create()
        {
            return new Tags();
        }

        public static Tags Create(string hostName)
        {
            var instance = new Tags();
            instance.Add(_host, hostName);
            return instance;
        }
    }
}


