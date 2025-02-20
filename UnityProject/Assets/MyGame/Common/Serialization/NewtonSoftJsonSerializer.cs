using Newtonsoft.Json;

namespace MyGame.Common.Serialization
{
    public class NewtonSoftJsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}