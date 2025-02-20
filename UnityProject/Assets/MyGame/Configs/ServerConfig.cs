using MyGame.Infrastructure;
using UnityEngine;

namespace MyGame.Configs
{
    [CreateAssetMenu(fileName = "ServerConfig", menuName = "MyGame/new ServerConfig")]
    public class ServerConfig : ScriptableObject, IServerConfig
    {
        [SerializeField] private string helloBaseUrl;
        [SerializeField] private int helloRandomSeed;

        public string HelloBaseUrl => helloBaseUrl;
        public int HelloRandomSeed => helloRandomSeed;
    }
}