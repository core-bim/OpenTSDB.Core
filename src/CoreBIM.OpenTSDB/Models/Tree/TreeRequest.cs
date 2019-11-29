using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Tree
{
    /// <summary>
    /// http://opentsdb.net/docs/build/html/api_http/tree/index.html
    /// </summary>
    public class TreeRequest
    {
        /// <summary>
        /// Used to fetch or modify a specific tree. *When creating a new tree, the tree value must not be present.
        /// </summary>
        [JsonProperty("treeId")]
        public int TreeId { get; set; }

        /// <summary>
        /// A brief, descriptive name for the tree. *Required only when creating a tree.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A longer description of what the tree contains
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Detailed notes about the tree
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Whether or not timeseries should be included in the tree if they fail to match one or more rule levels.
        /// </summary>
        [JsonProperty("strictMatch")]
        public bool StrictMatch { get; set; }

        /// <summary>
        /// 	Whether or not TSMeta should be processed through the tree. 
        /// 	By default this is set to false so that you can setup rules and test some objects before building branches.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Whether or not collisions and 'not matched' TSUIDs should be recorded. 
        /// This can create very wide rows.
        /// </summary>
        [JsonProperty("storeFailures")]
        public bool StoreFailures { get; set; }

        /// <summary>
        /// Used only when DELETE ing a tree, 
        /// if this flag is set to true, then the entire tree definition will be deleted along with all branches, 
        /// collisions and not matched entries
        /// </summary>
        [JsonProperty("definition")]
        public bool Definition { get; set; }

    }


}
