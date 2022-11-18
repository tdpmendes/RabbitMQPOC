using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQPOC
{
    public class POCWorker : BackgroundService
    {
        private readonly POCConsumer _consumer;
        private readonly IBus _bus;
        public POCWorker(IBus bus)
        {
            _consumer = new POCConsumer();
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            await _bus.Publish(new POCRabbitMessage { Content = $"The time is {DateTimeOffset.Now}" }, stoppingToken);

        }
    }
}
