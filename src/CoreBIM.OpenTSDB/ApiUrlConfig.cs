using OpenTSDB.Core.Extensions;
using System;

namespace OpenTSDB.Core
{
    public static class ApiUrlConfig
    {
        private const string DefaultHostUrl = "http://127.0.0.1:4242/"; 

        public static string BaseUrl { get; private set; }

        static ApiUrlConfig()
        {
            ResetBaseUrl();
        }

        public static void ChangeBaseUrl(string baseUrl)
        {
            BaseUrl = NormalizeUrl(baseUrl);
        }

        public static void ResetBaseUrl()
        {
            BaseUrl = DefaultHostUrl;
        }
        private static string NormalizeUrl(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != "http" && uriResult.Scheme != "https"))
            {
                throw new ArgumentException("Unexpected base URL: " + baseUrl);
            }

            return uriResult.ToString().EnsureEndsWith('/');
        }
    }
}
