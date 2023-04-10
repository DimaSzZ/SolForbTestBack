using Domain.Models.OrderItem;
using MediatR;

namespace Application.Commands.OrderItemActions.CreateUpdateItem;

public record CreateUpdateItemCommand(List<OrderItemDto> Item,int OrderId) : IRequest;