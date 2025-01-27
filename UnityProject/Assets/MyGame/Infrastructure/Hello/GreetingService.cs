using System.Threading.Tasks;
using MyGame.Domain.Hello;
using MyGame.Common.Logging;
using Unity.Plastic.Newtonsoft.Json;

namespace MyGame.Infrastructure.Hello
{
    public class GreetingService : IGreetingService
    {
        private readonly ILogger _logger;

        public GreetingService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<string> GetGreetingAsync(Name name)
        {
            var dto = name.ToDto();
            
            var json = JsonConvert.SerializeObject(dto);
            _logger.Info($"sending request: {json}");
            
            // simulate sending a request to a server
            await Task.Delay(1000);
            var result = "Hello, " + name.Text + "!";
            
            return result;
        }
    }
}