using Contracts.Commands;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Threading.Tasks;

namespace Endpoint;
public class CreateNewUserHandler : IHandleMessages<CreateNewUser>
{
    private readonly ILogger _logger;

    public CreateNewUserHandler(ILogger<CreateNewUserHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CreateNewUser message, IMessageHandlerContext context)
    {
        _logger.LogInformation($"Creating user {message.Name} with email {message.EmailAddress}");
        return Task.CompletedTask;
    }
}
