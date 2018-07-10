using System;
using System.Text;
using RabbitMQ.Client;
using Utility;

namespace Sender
{
    public class Sender
    {
        static void Main(string[] args)
        {
            var factory = QueueProperties.ConnectionFactory;

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                string message = "Hello World! This is second message";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

//https://github.com/rabbitmq/rabbitmq-tutorials/tree/master/dotnet