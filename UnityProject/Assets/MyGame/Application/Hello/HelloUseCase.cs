using System;
using System.Threading.Tasks;

namespace MyGame.Application.Hello
{
    public class HelloUseCase
    {
        private readonly IGreetingService _service;

        public HelloUseCase(IGreetingService service)
        {
            _service = service;
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
                    catch (Exception _)
                    {
                        return "Error: Failed to get greeting";
                    }
            }
        }
    }
}
