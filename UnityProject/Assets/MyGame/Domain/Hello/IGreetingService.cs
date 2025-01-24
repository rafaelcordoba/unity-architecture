using System.Threading.Tasks;

namespace MyGame.Domain.Hello
{
    public interface IGreetingService
    {
        Task<string> GetGreetingAsync(Name name);
    }
}