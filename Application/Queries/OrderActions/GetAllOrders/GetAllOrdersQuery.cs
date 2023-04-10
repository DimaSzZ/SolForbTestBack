using Domain.Models.Order;
using MediatR;

namespace Application.Queries.OrderActions.GetAllOrders;

public record GetAllOrdersQuery() : IRequest<List<Order>>;