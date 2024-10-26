using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Transport.InMemory;
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
            endpointConfiguration.UseSerialization<SystemJsonSerializer>();
            // TODO - Requires an upgrade in lib to use with NSB 8
            endpointConfiguration.UseTransport(new InMemoryTransport());
            return endpointConfiguration;
        });
        builder.ConfigureServices(services => { services.AddHostedService<Worker>(); });

        var host = builder.Build();
        await host.RunAsync();
    }
}