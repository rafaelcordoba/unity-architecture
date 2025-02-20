using System.Threading.Tasks;
using MyGame.Application.Hello;
using MyGame.Common.Net;
using MyGame.Common.Serialization;
using MyGame.Common.System;

namespace MyGame.Infrastructure.Hello
{
    public class ServerApi : IGreetingService
    {
        private readonly IRandom _random;
        private readonly IHttpHandler _httpHandler;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly string _baseUrl;

        public ServerApi(IServerConfig serverConfig,
            IJsonSerializer jsonSerializer,
            IHttpHandler httpHandler,
            IRandomFactory randomFactory)
        {
            _jsonSerializer = jsonSerializer;
            _httpHandler = httpHandler;
            _random = randomFactory.Create(serverConfig.HelloRandomSeed);
            _baseUrl = serverConfig.HelloBaseUrl;
        }

        public async Task<string> GetGreetingAsync(string name)
        {
            var randomNum = _random.Next(1, 4);
            using var response = await _httpHandler.GetAsync($"{_baseUrl}/todos/{randomNum}");
            response.EnsureSuccessStatusCode();
    
            var jsonString = await response.Content.ReadAsStringAsync();
            var helloResponse = _jsonSerializer.Deserialize<HelloResponse>(jsonString);
            
            return $"Greetings, {name}!\n" +
                   $"{helloResponse.Title}";
        }
    }
}