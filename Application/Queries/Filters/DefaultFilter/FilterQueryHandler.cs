using Domain.Interface.Repositories;
using Domain.Models.Order;
using MediatR;

namespace Application.Queries.Filters.DefaultFilter;

public class FilterQueryHandler : IRequestHandler<FilterQuery,List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public FilterQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(FilterQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrdersByFilter(
            request.Number,
            request.LowDate,
            request.HighDate,
            request.ProviderId,
            request.ProductName,
            request.Unit,
            request.ProviderName
        );
    }
}