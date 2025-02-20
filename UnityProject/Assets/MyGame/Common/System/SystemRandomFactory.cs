namespace MyGame.Common.System
{
    public class SystemRandomFactory : IRandomFactory
    {
        public IRandom Create(int seed) => 
            new SystemRandom(seed);
    }
}