using NewLab1_MinimalAPI.Models;
using Web_Book.Models;

namespace Web_Book.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO _responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
