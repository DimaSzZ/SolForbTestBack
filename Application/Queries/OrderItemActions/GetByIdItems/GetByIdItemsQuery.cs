using Domain.Models.OrderItem;
using MediatR;

namespace Application.Queries.OrderItemActions.GetByIdItems;

public record GetByIdItemsQuery(int Id) : IRequest<List<OrderItem>>;