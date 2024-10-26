using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using System.Threading.Tasks;

namespace Endpoint;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);

        builder.UseNServiceBus(ctx =>
        {
            var endpointConfiguration = new EndpointConfiguration("Endpoint");
            endpointConfiguration.UseTransport<LearningTransport>();
            return endpointConfiguration;
        });
        builder.ConfigureServices(services => { services.AddHostedService<Worker>(); });

        var host = builder.Build();
        await host.RunAsync();
    }
}