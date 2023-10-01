using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using static Web_Book.StaticDetails;
namespace Web_Book.Models
    
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }
    }
}
