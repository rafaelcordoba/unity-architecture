using System.Threading.Tasks;
using MyGame.Common.Logging;
using MyGame.Domain.Hello;

namespace MyGame.Application.Hello
{
    public class HelloUseCase
    {
        private readonly IGreetingService _service;
        private readonly ILogger _logger;

        public HelloUseCase(IGreetingService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<string> HelloAsync(string name)
        {
            var nameModel = new Name(name);
            if (!nameModel.IsValid)
            {
                _logger.Error($"Invalid name: {name}");
                return $"Error: Invalid name: {name}";
            }

            var greetingText = await _service.GetGreetingAsync(nameModel);
            _logger.Info($"Hello, {nameModel.Text}!");
            return greetingText;
        }
    }
}
