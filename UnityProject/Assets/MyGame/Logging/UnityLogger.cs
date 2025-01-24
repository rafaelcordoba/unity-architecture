using UnityEngine;

namespace MyGame.Logging
{
    public class UnityLogger : MyGame.Common.Logging.ILogger
    {
        public void Info(string message)
        {
            Debug.Log(message);
        }

        public void Warn(string message)
        {
            Debug.LogWarning(message);
        }

        public void Error(string message)
        {
            Debug.LogError(message);
        }
    }
}