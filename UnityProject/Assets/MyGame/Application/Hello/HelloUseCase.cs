using System;
using System.Threading.Tasks;
using MyGame.Common.Logging;

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
            if (string.IsNullOrEmpty(name))
                return "Error: Name cannot be empty";
            
            switch (name.Length)
            {
                case > 10:
                    return "Error: Name is too long";
                case < 3:
                    return "Error: Name is too short";
                default:
                    try
                    {
                        return await _service.GetGreetingAsync(name);
                    }
                    catch (Exception exception)
                    {
                        
                        _logger.Error($"{exception.Message} {exception.StackTrace}");
                        return "Error: Failed to get greeting";
                    }
            }
        }
    }
}
