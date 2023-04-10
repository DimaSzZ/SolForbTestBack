using Domain.Interface;
using MediatR;

namespace Application.Commands.OrderItemActions.DeleteItem;

public class DeleteItemHandler : IRequestHandler<DeleteItemCommand>
{
    private readonly IOrderItemRepository _orderItemRepository;
    public DeleteItemHandler(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        await _orderItemRepository.DeleteOrderItem(request.Id,cancellationToken);
    }
}