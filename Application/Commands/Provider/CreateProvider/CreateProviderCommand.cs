using MediatR;

namespace Application.Commands.Provider.CreateProvider;

public record CreateProviderCommand(string Name) : IRequest;