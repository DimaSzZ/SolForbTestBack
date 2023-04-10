using Domain.Interface.Repositories;
using Domain.Models.Order;
using MediatR;

namespace Application.Queries.OrderActions.GetAllOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery,List<Order>>
{
    private readonly IOrderRepository _orderRepository;
    public GetAllOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.ShowAllOrders(cancellationToken);
    }
}