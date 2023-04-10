using Domain.Interface.Repositories;
using Domain.Models.Order;
using MediatR;

namespace Application.Queries.OrderActions.GetByIdOrder;

public class GetByIdOrderHandler : IRequestHandler<GetByIdOrderQuery,Order>
{
    private readonly IOrderRepository _orderRepository;
    public GetByIdOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.OneById(request.Id, cancellationToken);
    }
}