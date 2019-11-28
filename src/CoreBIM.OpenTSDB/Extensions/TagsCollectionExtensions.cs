using OpenTSDB.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTSDB.Core.Extensions
{
    public static class TagsCollectionExtensions
    {
        public static TagsCollection SetTag(this TagsCollection tagsCollection, string tagName, string tagValue)
        {
            if (string.IsNullOrWhiteSpace(tagName)) throw new ArgumentException("tagName", nameof(tagName));
            if (string.IsNullOrWhiteSpace(tagValue)) throw new ArgumentException("tagValue", nameof(tagValue));

            tagsCollection[tagName] = tagValue;

            return tagsCollection;
        }

        public static TagsCollection SetHost(this TagsCollection tagsCollection, string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName)) throw new ArgumentException("hostName", nameof(hostName));

            return tagsCollection.SetTag(TagsCollection.HOST, hostName);
        }

        public static string GetHost(this TagsCollection tagsCollection)
        {
            return tagsCollection[TagsCollection.HOST];
        }

        public static TagsCollection ExtendWith(this TagsCollection first, TagsCollection second)
        {
            foreach (var keyValuePair in second)
            {
                first.SetTag(keyValuePair.Key, keyValuePair.Value);
            }

            return first;
        }
    }
}
