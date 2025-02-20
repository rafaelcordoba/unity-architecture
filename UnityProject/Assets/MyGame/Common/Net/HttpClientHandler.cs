using System.Net.Http;
using System.Threading.Tasks;

namespace MyGame.Common.Net
{
    public class HttpClientHandler : HttpClient, IHttpHandler
    {
        public new Task<HttpResponseMessage> GetAsync(string url)
        {
            return base.GetAsync(url);
        }

        public new Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return base.PostAsync(url, content);
        }
    }
}