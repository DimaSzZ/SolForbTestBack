using Domain.Models.Order;
using MediatR;

namespace Application.Queries.OrderActions.GetByIdOrder;

public record GetByIdOrderQuery(int Id) : IRequest<Order>;