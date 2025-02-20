using Newtonsoft.Json;

namespace MyGame.Infrastructure.Hello
{
    public class HelloResponse
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}