using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Customer.MessageQ
{
    public class CustomerDeleteProducer: IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "CustomerDelete",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(
                exchange: "",
                routingKey: "CustomerDelete",
                body: body);
            
            
            Console.WriteLine($" Sent Message :  {message}");
         
        }  
    }
}