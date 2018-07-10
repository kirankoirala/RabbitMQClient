using System;
using RabbitMQ.Client;

namespace Utility
{
    public static class QueueProperties
    {
        public static ConnectionFactory ConnectionFactory => new ConnectionFactory() { HostName = "localhost", Port = 32775, UserName = "testRabit", Password = "password" };

    }
}
