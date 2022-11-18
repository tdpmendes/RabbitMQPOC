using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQPOC
{
    public class POCConsumer : IConsumer<POCRabbitMessage>
    {
        public Task Consume(ConsumeContext<POCRabbitMessage> context)
        {
            Console.Write(context.Message.Content);
            return Task.CompletedTask;
        }
    }
}
