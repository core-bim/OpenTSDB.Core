using OpenTSDB.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTSDB.Core.Models
{
    /// <summary>
    /// Defines a key/value metadata colection used for openTSDB data submission
    /// </summary>
    public class TagsCollection : Dictionary<string, string>
    {
        /// <summary>
        /// Defines the constant data point origin tag name
        /// </summary>
        public const string HOST = "host";

        public const string HOST_ARTIFICIAL = "host_artificial";


        public static TagsCollection New()
        {
            return new TagsCollection();
        }

        public static TagsCollection New(string machineName)
        {
            var instance = new TagsCollection();
            instance.Add(HOST_ARTIFICIAL, "true");
            instance.SetHost(machineName);

            return instance;
        }


        protected TagsCollection()
        {
            Add(HOST, Environment.MachineName);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Keys.Aggregate(0, (current, key) => (current * 333) ^ (key != null ? key.GetHashCode() : 0));
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IDictionary<string, string>))
            {
                return false;
            }

            var second = (IDictionary<string, string>)obj;

            foreach (var keyValuePair in this)
            {
                if (!second.ContainsKey(keyValuePair.Key))
                {
                    return false;
                }
                if (second[keyValuePair.Key] != keyValuePair.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}


