using Contracts.Commands;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint;
public class Worker : BackgroundService
{
    private readonly IMessageSession messageSession;

    public Worker(IMessageSession messageSession)
    {
        this.messageSession = messageSession;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await messageSession.SendLocal(new CreateNewUserCommand("bob@test.com", "Bob"), stoppingToken);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
