using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Send
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "1", Password = "1", Port = 5672 };
            factory.VirtualHost = "TestByArjun";

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "This is Arjun here.";
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
