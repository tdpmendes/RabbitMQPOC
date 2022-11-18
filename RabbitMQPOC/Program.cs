using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RabbitMQPOC
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }   
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<POCConsumer>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            //cfg.Host("localhost", "application", h => {
                            //    h.Username("guest");
                            //    h.Password("guest");
                            //    
                            //});



                            cfg.ConfigureEndpoints(context);
                        });

                    });

                    services.AddHostedService<POCWorker>();
                });
        
    }
}
