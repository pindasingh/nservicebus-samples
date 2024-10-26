using NServiceBus;

namespace Contracts.Commands;
public record CreateNewUserCommand(
    string EmailAddress,
    string Name)
    : ICommand;
