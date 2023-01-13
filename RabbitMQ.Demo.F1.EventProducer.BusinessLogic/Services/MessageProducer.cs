
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Models.Input;

namespace RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Services
{
    public class MessageProducer:IMessageProducer
    {
        public async Task<bool> SendMessage(EventRequest request)
        {
            var factory = new ConnectionFactory() { HostName = "localhost",UserName = "guest",Password = "guest",Port = 5672};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    /*
                    channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
                    */
                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body);
                }
                
            }
            return true;
        }
    }
}
