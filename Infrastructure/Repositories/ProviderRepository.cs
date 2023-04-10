using Domain.Interface;
using Infrastructure.Parsistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProviderRepository: IProviderRepository
{
    public ProviderRepository(PgDbContext ctx)
    {
        _ctx = ctx;
    }

    private readonly PgDbContext _ctx;
    
    public async Task AddProvider(Domain.Models.Provider.Provider provider, CancellationToken cancellationToken)
    {
        await _ctx.Providers.AddAsync(provider,cancellationToken);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public Task<List<Domain.Models.Provider.Provider>> ShowAllProviders(CancellationToken cancellationToken)
    {
        return _ctx.Providers.ToListAsync(cancellationToken);
    }
}