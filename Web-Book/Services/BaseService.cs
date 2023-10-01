using Web_Book.Models;
using Microsoft.Identity.Client;
using System.Text;
using Newtonsoft.Json;

namespace Web_Book.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO _responseModel { get; set; }
        public IHttpClientFactory _httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _responseModel = new ResponseDTO();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("BookApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/Json");
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.ApiType)
                {
                    case StaticDetails.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception e)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        
    }
}
