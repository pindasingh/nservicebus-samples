using Contracts.Commands;
using Microsoft.Extensions.Logging;
using NServiceBus;
using System.Threading.Tasks;

namespace Endpoint;
public class CreateNewUserCommandHandler : IHandleMessages<CreateNewUserCommand>
{
    private readonly ILogger _logger;

    public CreateNewUserCommandHandler(ILogger<CreateNewUserCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CreateNewUserCommand message, IMessageHandlerContext context)
    {
        _logger.LogInformation($"Creating user {message.Name} with email {message.EmailAddress}");
        return Task.CompletedTask;
    }
}
