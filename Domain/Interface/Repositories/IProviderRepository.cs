using Domain.Models.OrderItem;
using Domain.Models.Provider;

namespace Domain.Interface;

public interface IProviderRepository
{
    public Task AddProvider(Provider provider,CancellationToken cancellationToken);
    public Task<List<Provider>> ShowAllProviders(CancellationToken cancellationToken);
}