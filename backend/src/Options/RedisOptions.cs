using System;

namespace JobGrabber.Backend.Options
{
    public sealed class RedisOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public int RetryConnectCount { get; set; } = 2;

        public string Configuration => $"{Host}:{Port}, connectRetry={RetryConnectCount}";
    }
}
