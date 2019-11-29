using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Search
{
    public class SearchTsmetaResponse:SearchResponse<ResultsItem>
    {
       
    }

    public class Metric
    {
        /// <summary>
        /// 
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string notes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string custom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string displayName { get; set; }
    }


    public class ResultsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string tsuid { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public Metric metric { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public List<Metric> tags { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public string notes { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public int created { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string units { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public int retention { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public int max { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public int min { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string displayName { get; set; }
      
        /// <summary>
        /// 
        /// </summary>
        public string dataType { get; set; }
     
        /// <summary>
        /// 
        /// </summary>
        public int lastReceived { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public int totalDatapoints { get; set; }
    }

}
