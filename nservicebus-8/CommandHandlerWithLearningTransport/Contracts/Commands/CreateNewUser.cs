using NServiceBus;

namespace Contracts.Commands;
public record CreateNewUser(
    string EmailAddress,
    string Name)
    : ICommand;
