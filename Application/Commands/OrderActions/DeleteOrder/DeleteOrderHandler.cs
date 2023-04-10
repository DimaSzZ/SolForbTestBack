using Domain.Interface;
using Domain.Interface.Repositories;
using MediatR;

namespace Application.Commands.OrderActions.DeleteOrder;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public DeleteOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.DeleteOrder(request.Id, cancellationToken);
    }
}