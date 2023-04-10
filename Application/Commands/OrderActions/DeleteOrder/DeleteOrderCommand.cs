using MediatR;

namespace Application.Commands.OrderActions.DeleteOrder;

public record DeleteOrderCommand(int Id) : IRequest;