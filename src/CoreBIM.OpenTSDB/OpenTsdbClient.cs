using Flurl.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OpenTSDB.Core
{
    public class OpenTsdbClient : IDisposable
    {
        private static FlurlClient _client;
        //Time out
        public static int? TimeoutSeconds { get; set; } = 30;

        #region PostAsync<T>

        public async Task<T> PostAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, string.Empty, string.Empty);
        }

        public async Task<T> PostAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, string.Empty);
        }

        public async Task<T> PostAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PostJsonAsync(inputDto);

            return await httpResponse.ReceiveJson<T>();
        }

        public async Task<T> PostMultipartAsync<T>(string endpoint, Stream stream, string fileName)
        {
            var httpResponse = GetClient()
                    .Request(endpoint)
                    .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", stream, fileName));

            return await httpResponse.ReceiveJson<T>();
        }

        public async Task<T> PostMultipartAsync<T>(string endpoint, string filePath)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", filePath));

            return await httpResponse.ReceiveJson<T>();
        }

        #endregion

        #region  PostAsync

        public async Task PostAsync(string endpoint)
        {
            await PostAsync(endpoint, string.Empty, string.Empty, true);
        }

        public async Task PostAsync(string endpoint, object inputDto)
        {
            await PostAsync(endpoint, inputDto, string.Empty, true);
        }

        public async Task PostAnonymousAsync(string endpoint, object inputDto)
        {
            await PostAsync(endpoint, inputDto, string.Empty, true);
        }

        public async Task PostAsync(string endpoint, object inputDto, object queryParameters)
        {
            await PostAsync(endpoint, inputDto, queryParameters, true);
        }

        public async Task PostAsync(string endpoint, object inputDto, object queryParameters,
            bool stripAjaxResponseWrapper)
        {
            await GetClient()
                  .Request(endpoint)
                  .SetQueryParams(queryParameters)
                  .PostJsonAsync(inputDto);
        }

        #endregion

        #region  GetAsync<T>

        public async Task<T> GetAsync<T>(string endpoint)
        {
            return await GetAsync<T>(endpoint, string.Empty);
        }


        public async Task<T> GetMethodByGet<T>(string endpoint, string queryName, object queryParameters)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParam(queryName, queryParameters);
            var response = await httpResponse.GetJsonAsync<T>();
            return response;

        }



        public async Task<T> GetAsync<T>(string endpoint, object queryParameters)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters);
            return await httpResponse.GetJsonAsync<T>();
        }

        #endregion

        #region  GetAsync

        public async Task GetAsync(string endpoint)
        {
            await GetAsync(endpoint, string.Empty);
        }


        public async Task GetAsync(string endpoint, object queryParameters)
        {
            await GetClient()
             .Request(endpoint)
             .SetQueryParams(queryParameters)
             .GetAsync();
        }

        #endregion

        #region DeleteAsync

        public async Task DeleteAsync(string endpoint)
        {
            await DeleteAsync(endpoint, string.Empty);
        }

        public async Task DeleteAsync(string endpoint, object queryParameters)
        {
            await GetClient()
                    .Request(endpoint)
                    .SetQueryParams(queryParameters)
                    .DeleteAsync();
        }

        public async Task DeleteMethod(string endpoint, string queryName, object queryParameters)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParam(queryName, queryParameters);
            await httpResponse.DeleteAsync();
        }


        #endregion

        #region DeleteAsync<T>

        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            return await DeleteAsync<T>(endpoint, string.Empty);
        }

        public async Task<T> DeleteAsync<T>(string endpoint, object queryParameters)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .DeleteAsync();
            return await httpResponse.ReceiveJson<T>();
        }

        #endregion

        #region PutAsync<T>

        public async Task<T> PutAsync<T>(string endpoint)
        {
            return await PutAsync<T>(endpoint, string.Empty, string.Empty);
        }

        public async Task<T> PutAsync<T>(string endpoint, object inputDto)
        {
            return await PutAsync<T>(endpoint, inputDto, string.Empty);
        }


        public async Task<T> PutAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PutJsonAsync(inputDto);

            return await httpResponse.ReceiveJson<T>();
        }


        #endregion

        #region  PutAsync

        public async Task PutAsync(string endpoint)
        {
            await PutAsync(endpoint, string.Empty, string.Empty);
        }

        public async Task PutAsync(string endpoint, object inputDto)
        {
            await PutAsync(endpoint, inputDto, string.Empty);
        }

        public async Task PutAsync(string endpoint, object inputDto, object queryParameters)
        {
            await GetClient()
                  .Request(endpoint)
                  .SetQueryParams(queryParameters)
                  .PutJsonAsync(inputDto);
        }

        #endregion

        #region Flurl Client
        public FlurlClient GetClient()
        {
            if (_client == null)
            {
                CreateClient();
            }
            AddHeaders();
            return _client;
        }
        private static void CreateClient()
        {
            _client = new FlurlClient(ApiUrlConfig.BaseUrl);
            if (TimeoutSeconds.HasValue)
            {
                _client.WithTimeout(TimeoutSeconds.Value);
            }
        }
        private void AddHeaders()
        {
            _client.HttpClient.DefaultRequestHeaders.Clear();
            _client.WithHeader("Accept", "application/json");
            _client.WithHeader("Accept-Encoding", "gzip,deflate");
            _client.WithHeader("Accept-Encoding", "gzip, deflate");
            _client.WithHeader("Content-Type", "application/json");
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            _client?.Dispose();
        }
        #endregion
    }
}
