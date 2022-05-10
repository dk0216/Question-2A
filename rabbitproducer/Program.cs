using System;
using RabbitMQ.Client;
using System.Text;
 
namespace rabbitproducer
{
   class Program
   {
       static void Main(string[] args)
       {
       var factory = new ConnectionFactory() { HostName = "localhost" };
       using(var connection = factory.CreateConnection())
       using(var channel = connection.CreateModel())
       {
 
           string message = "Hello from rabbitproducer";
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
