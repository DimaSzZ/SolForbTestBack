using Domain.Models.Provider;
using MediatR;

namespace Application.Queries.ProviderAction.GetAllProviders;

public record GetAllProvidersQuery() : IRequest<List<Provider>>;