using System.Threading.Tasks;

namespace MyGame.Application.Hello
{
    public interface IGreetingService
    {
        Task<string> GetGreetingAsync(string name);
    }
}