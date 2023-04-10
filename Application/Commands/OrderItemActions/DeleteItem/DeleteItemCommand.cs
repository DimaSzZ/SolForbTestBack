using MediatR;

namespace Application.Commands.OrderItemActions.DeleteItem;

public record DeleteItemCommand(int Id) : IRequest;