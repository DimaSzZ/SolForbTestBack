using Domain.Interface;
using Domain.Models.Provider;
using MediatR;

namespace Application.Queries.ProviderAction.GetAllProviders;

public class GetAllProvidersHandler : IRequestHandler<GetAllProvidersQuery,List<Provider>>
{
    private readonly IProviderRepository _providerRepository;
    public GetAllProvidersHandler(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<List<Provider>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        return await _providerRepository.ShowAllProviders(cancellationToken);
    }
}