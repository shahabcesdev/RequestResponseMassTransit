using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment01.ConsoleProcessRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ReceiveEndpoint("order-service", e =>
                {
                    e.Consumer<CheckOrderStatusConsumer>();
                });
            });

            await busControl.StartAsync();

            try
            {
                Console.WriteLine("Press enter to exit");

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}
