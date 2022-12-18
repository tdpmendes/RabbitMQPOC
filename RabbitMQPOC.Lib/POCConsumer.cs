using MassTransit;
using System;
using System.Threading.Tasks;

namespace RabbitMQPOC.Lib
{
    public class POCConsumer : IConsumer<POCRabbitMessage>
    {
        public Task Consume(ConsumeContext<POCRabbitMessage> context)
        {
            Console.Write($"Received on {DateTime.Now} :" + context.Message.Content);
            return Task.CompletedTask;
        }
    }
}
