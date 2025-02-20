namespace MyGame.Common.System
{
    public interface IRandomFactory
    {
        IRandom Create(int seed);
    }
}