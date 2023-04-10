using Domain.Interface;
using MediatR;

namespace Application.Commands.Provider.CreateProvider;

public class CreateProviderHandler : IRequestHandler<CreateProviderCommand>
{
    private readonly IProviderRepository _providerRepository;
    public CreateProviderHandler(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Models.Provider.Provider{ Name = request.Name};
        await _providerRepository.AddProvider(data, cancellationToken);
    }
}