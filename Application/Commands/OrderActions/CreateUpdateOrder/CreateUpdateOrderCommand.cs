using Domain.Models.Order;
using MediatR;

namespace Application.Commands.OrderActions.CreateUpdateOrder;

public record CreateUpdateOrderCommand(int? Id,string Number,DateTime Date,int ProviderId) : IRequest<int>;