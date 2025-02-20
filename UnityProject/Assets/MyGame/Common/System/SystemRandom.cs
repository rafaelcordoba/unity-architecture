using System;

namespace MyGame.Common.System
{
    public class SystemRandom : IRandom
    {
        private readonly Random _random;
        
        public SystemRandom(int seed) => _random = new Random(seed);
        public int Next() => _random.Next();
        public int Next(int maxValue) => _random.Next(maxValue);
        public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
    }
}