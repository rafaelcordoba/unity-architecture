namespace MyGame.Infrastructure
{
    public interface IServerConfig
    {
        string HelloBaseUrl { get; }
        int HelloRandomSeed { get; }
    }
}