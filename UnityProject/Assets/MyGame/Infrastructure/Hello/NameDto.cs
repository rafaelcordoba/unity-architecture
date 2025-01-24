using System;
using Unity.Plastic.Newtonsoft.Json;

namespace MyGame.Infrastructure.Hello
{
    [Serializable]
    public class NameDto
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}