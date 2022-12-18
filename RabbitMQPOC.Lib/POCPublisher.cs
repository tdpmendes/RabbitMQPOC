using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQPOC.Lib
{
    public class POCPublisher : BackgroundService
    {
        private readonly POCConsumer _consumer;
        private readonly IBus _bus;
        public POCPublisher(IBus bus)
        {
            _consumer = new POCConsumer();
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            while (true)
            {
                Console.WriteLine("Write a message to send to the consumer or type q to quit: ");
                var content = Console.ReadLine();

                if (content.ToLowerInvariant() == "q") break;

                await _bus.Publish(new POCRabbitMessage { Content = content + $" sent {DateTimeOffset.Now}" }, stoppingToken);
            }
        }
    }
}
