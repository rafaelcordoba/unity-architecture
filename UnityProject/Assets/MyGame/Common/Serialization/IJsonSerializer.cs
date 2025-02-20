namespace MyGame.Common.Serialization
{
    public interface IJsonSerializer
    {
        T Deserialize<T>(string jsonString);
        string Serialize<T>(T obj);
    }
}