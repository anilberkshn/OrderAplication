// using System;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Hosting;
// using RabbitMQ.Client;
// using RabbitMQ.Client.Events;
//
// namespace OrderCase.MessageQ
// {
//     public class CustomerConsumer :BackgroundService
//     {
//         private readonly IConnection _connection;
//         private readonly IModel _channel;
//
//         public CustomerConsumer()
//         { 
//             var factory = new ConnectionFactory{HostName = "localhost"};
//             _connection = factory.CreateConnection();
//             _channel = _connection.CreateModel();
//         }
//         
//         protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//         {
//             var consumer = new EventingBasicConsumer(_channel);
//             consumer.Received += (model, ea) =>
//             {
//                 var body = ea.Body.ToArray();
//                 var message = Encoding.UTF8.GetString(body);
//                 Console.WriteLine("Mesaj alındı: " + message);
//                 _channel.BasicAck(ea.DeliveryTag, multiple: false);
//             };
//
//             _channel.BasicConsume(queue: "CustomerDelete", autoAck: false, consumer: consumer);
//
//             while (!stoppingToken.IsCancellationRequested)
//             { 
//               await  Task.Delay(5000, stoppingToken); 
//             } 
//         }
//         public override void Dispose() // StopListening
//         {
//             _channel.Close();
//             _connection.Close();
//             base.Dispose();
//         }
//         
//         private void DeleteCustomerOrders(Guid customerId)
//         {
//             
//         }
//     }
// }