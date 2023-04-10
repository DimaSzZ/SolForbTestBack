using Domain.Models.Order;
using MediatR;

namespace Application.Queries.Filters.DefaultFilter;

public record FilterQuery(string? Number,DateTime? LowDate,DateTime? HighDate, int? ProviderId,string? ProductName,string? Unit,string? ProviderName): IRequest<List<Order>>;