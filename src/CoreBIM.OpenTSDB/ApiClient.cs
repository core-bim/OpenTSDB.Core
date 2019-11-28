using Flurl.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OpenTSDB.Core
{
    public class ApiClient : IDisposable
    {
        private static FlurlClient _client;     
        //Time out
        public static int? TimeoutSeconds { get; set; } = 30;

        #region PostAsync<T>

        public async Task<T> PostAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, null, null,  true);
        }

        public async Task<T> PostAnonymousAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, null, null, true);
        }

        public async Task<T> PostAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, null,  true);
        }

        public async Task<T> PostAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            return await PostAsync<T>(endpoint, inputDto, queryParameters,  true);
        }

        public async Task<T> PostAnonymousAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, null, true);
        }

        public async Task<T> PostAsync<T>(string endpoint, object inputDto, object queryParameters,bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PostJsonAsync(inputDto);

            if (stripAjaxResponseWrapper)
            {
                var response = await httpResponse.ReceiveJson<T>();
                ValidateAbpResponse(response);
                return response;
            }

            return await httpResponse.ReceiveJson<T>();
        }

        public async Task<T> PostMultipartAsync<T>(string endpoint, Stream stream, string fileName, bool stripAjaxResponseWrapper = true)
        {
            var httpResponse = GetClient()
                    .Request(endpoint)
                    .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", stream, fileName));

            if (stripAjaxResponseWrapper)
            {
                var response = await httpResponse.ReceiveJson<T>();
                ValidateAbpResponse(response);
                return response;
            }

            return await httpResponse.ReceiveJson<T>();
        }

        public async Task<T> PostMultipartAsync<T>(string endpoint, string filePath, bool stripAjaxResponseWrapper = true)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", filePath));

            if (stripAjaxResponseWrapper)
            {
                var response = await httpResponse.ReceiveJson<T>();
                ValidateAbpResponse(response);
                return response;
            }

            return await httpResponse.ReceiveJson<T>();
        }

        #endregion

        #region  PostAsync

        public async Task PostAsync(string endpoint)
        {
            await PostAsync(endpoint, null, null,  true);
        }

        public async Task PostAsync(string endpoint, object inputDto)
        {
            await PostAsync(endpoint, inputDto, null,  true);
        }

        public async Task PostAnonymousAsync(string endpoint, object inputDto)
        {
            await PostAsync(endpoint, inputDto, null, true);
        }

        public async Task PostAsync(string endpoint, object inputDto, object queryParameters)
        {
            await PostAsync(endpoint, inputDto, queryParameters,  true);
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
            return await GetAsync<T>(endpoint, null);
        }


        public async Task<T> GetAnonymousAsync<T>(string endpoint)
        {
            return await GetAsync<T>(endpoint, null, true);
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
            return await GetAsync<T>(endpoint, queryParameters,  true);
        }

        public async Task<T> GetAsync<T>(string endpoint, object queryParameters, bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters);

            if (stripAjaxResponseWrapper)
            {
                var response = await httpResponse.GetJsonAsync<T>();
                ValidateAbpResponse(response);
                return response;
            }

            return await httpResponse.GetJsonAsync<T>();
        }

        #endregion

        #region  GetAsync

        public async Task GetAsync(string endpoint)
        {
            await GetAsync(endpoint, null);
        }

        public async Task GetAsync(string endpoint, object queryParameters)
        {
            await GetAsync(endpoint, queryParameters,  true);
        }

        public async Task GetAsync(string endpoint, object queryParameters,  bool stripAjaxResponseWrapper)
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
            await DeleteAsync(endpoint, null);
        }

        public async Task DeleteAsync(string endpoint, object queryParameters)
        {
            await DeleteAsync(endpoint, queryParameters);
        }

        public async Task DeleteAsync(string endpoint, object queryParameters, string accessToken)
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
            return await DeleteAsync<T>(endpoint, null);
        }

        public async Task<T> DeleteAsync<T>(string endpoint, object queryParameters)
        {
            return await DeleteAsync<T>(endpoint, queryParameters,  true);
        }

        public async Task<T> DeleteAsync<T>(string endpoint, object queryParameters,  bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .DeleteAsync();

            if (stripAjaxResponseWrapper)
            {
                var response = await httpResponse.ReceiveJson<T>();
                ValidateAbpResponse(response);
                return response;
            }

            return await httpResponse.ReceiveJson<T>();
        }

        #endregion

        #region PutAsync<T>

        public async Task<T> PutAsync<T>(string endpoint)
        {
            return await PutAsync<T>(endpoint, null, null,  true);
        }

        public async Task<T> PutAsync<T>(string endpoint, object inputDto)
        {
            return await PutAsync<T>(endpoint, inputDto, null,  true);
        }

        public async Task<T> PutAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            return await PutAsync<T>(endpoint, inputDto, queryParameters,  true);
        }

        public async Task<T> PutAsync<T>(string endpoint, object inputDto, object queryParameters, bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PutJsonAsync(inputDto);

            if (stripAjaxResponseWrapper)
            {
                var response = await httpResponse.ReceiveJson<T>();
                ValidateAbpResponse(response);
                return response;
            }
            return await httpResponse.ReceiveJson<T>();
        }

      
        #endregion

        #region  PutAsync

        public async Task PutAsync(string endpoint)
        {
            await PutAsync(endpoint, null, null,  true);
        }

        public async Task PutAsync(string endpoint, object inputDto)
        {
            await PutAsync(endpoint, inputDto, null,  true);
        }

        public async Task PutAsync(string endpoint, object inputDto, object queryParameters)
        {
            await PutAsync(endpoint, inputDto, queryParameters,  true);
        }

        public async Task PutAsync(string endpoint, object inputDto, object queryParameters, 
            bool stripAjaxResponseWrapper)
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
        }

        private void ValidateAbpResponse<T>(T response)
        {
            if (response == null)
            {
                return;
            }
          
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
