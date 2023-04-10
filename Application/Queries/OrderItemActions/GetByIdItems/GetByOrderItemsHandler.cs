using Application.Queries.OrderActions.GetByIdOrder;
using Domain.Interface;
using Domain.Models.OrderItem;
using MediatR;

namespace Application.Queries.OrderItemActions.GetByIdItems;

public class GetByOrderItemsHandler : IRequestHandler<GetByIdItemsQuery,List<OrderItem>>
{
    private readonly IOrderItemRepository _orderItemRepository;

    public GetByOrderItemsHandler(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task<List<OrderItem>> Handle(GetByIdItemsQuery request, CancellationToken cancellationToken)
    {
        return await _orderItemRepository.ShowSingleOrderItems(request.Id, cancellationToken);
    }
}