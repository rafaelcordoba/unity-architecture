using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyGame.Application.Hello;
using Newtonsoft.Json;

namespace MyGame.Infrastructure.Hello
{
    public class ServerApi : IGreetingService
    {
        private readonly Random _random;
        private readonly HttpClient _httpClient;

        public ServerApi(IServerConfig serverConfig)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(serverConfig.HelloBaseUrl)
            };
            _random = new Random(serverConfig.HelloRandomSeed);
        }

        public async Task<string> GetGreetingAsync(string name)
        {
            var randomNum = _random.Next(1, 4);
            using var response = await _httpClient.GetAsync($"todos/{randomNum}");
            response.EnsureSuccessStatusCode();
    
            var jsonString = await response.Content.ReadAsStringAsync();
            var helloResponse = JsonConvert.DeserializeObject<HelloResponse>(jsonString);
            
            return $"Greetings, {name}!\n" +
                   $"{helloResponse.Title}";
        }
    }
}