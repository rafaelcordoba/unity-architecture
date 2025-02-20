using System.Net.Http;
using System.Threading.Tasks;

namespace MyGame.Common.Net
{
    public interface IHttpHandler
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}