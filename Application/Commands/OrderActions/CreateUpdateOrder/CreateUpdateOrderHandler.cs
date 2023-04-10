using Domain.Interface.Repositories;
using Domain.Models.Order;
using MediatR;

namespace Application.Commands.OrderActions.CreateUpdateOrder;

public class CreateUpdateOrderHandler : IRequestHandler<CreateUpdateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public  CreateUpdateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateUpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var data = new Order(
            request.Number,
            request.Date,
            request.ProviderId
            );
        if (request.Id != null) 
        {
            data.Id = (int)request.Id;
        }
        await _orderRepository.SaveOrder(data, cancellationToken);
    }
}