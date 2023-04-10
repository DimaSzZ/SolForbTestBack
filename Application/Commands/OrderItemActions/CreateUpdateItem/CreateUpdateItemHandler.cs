using Domain.Interface;
using Domain.Models.Order;
using Domain.Models.OrderItem;
using MediatR;

namespace Application.Commands.OrderItemActions.CreateUpdateItem;

public class CreateUpdateItemHandler : IRequestHandler<CreateUpdateItemCommand>
{
    private readonly IOrderItemRepository _orderItemRepository;
    public CreateUpdateItemHandler(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task Handle(CreateUpdateItemCommand request, CancellationToken cancellationToken)
    {
        var data = request.Item.Select(oi => new OrderItem
        {
            Id = oi.Id,
            Name = oi.Name,
            Quantity = oi.Quantity,
            Unit = oi.Unit,
            OrderId = oi.OrderId
        }).ToList();
        await _orderItemRepository.SaveOrderItem(data,request.OrderId, cancellationToken);
    }
}