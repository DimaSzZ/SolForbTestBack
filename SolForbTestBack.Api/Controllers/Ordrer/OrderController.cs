using Application.Commands.OrderActions.CreateUpdateOrder;
using Application.Commands.OrderActions.DeleteOrder;
using Application.Queries.OrderActions.GetAllOrders;
using Application.Queries.OrderActions.GetByIdOrder;
using Microsoft.AspNetCore.Mvc;

namespace SolForbTestBack.Controllers.Ordrer;

[ApiController]
[Route("api/order")]
public class OrderController : BaseController
{
    
    [HttpPost("save-order")]
    public async Task<IActionResult> SaveOrder([FromBody]CreateUpdateOrderCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("Order saved");
    }
    [HttpDelete("delete-order/{id:int}")]
    public async Task<IActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteOrderCommand(id), cancellationToken);
        return Ok("Order deleted");
    }
    [HttpGet("get-one-order/{id:int}")]
    public async Task<IActionResult> GetOneOrder(int id,CancellationToken cancellationToken)
    {
        var resposne = await Mediator.Send(new GetByIdOrderQuery(id), cancellationToken);
        return Ok(resposne);
    }
    [HttpGet("get-all-order")]
    public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
    {
        var resposne = await Mediator.Send(new GetAllOrdersQuery(), cancellationToken);
        return Ok(resposne);
    }
}