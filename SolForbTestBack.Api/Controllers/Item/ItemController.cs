using Application.Commands.OrderItemActions.CreateUpdateItem;
using Application.Commands.OrderItemActions.DeleteItem;
using Application.Queries.OrderItemActions.GetByIdItems;
using Microsoft.AspNetCore.Mvc;

namespace SolForbTestBack.Controllers.Item;
[ApiController]
[Route("api/item")]
public class ItemController : BaseController
{
    [HttpPost("save-items")]
    public async Task<IActionResult> SaveItems([FromBody]CreateUpdateItemCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("items saved");
    }
    [HttpDelete("delete-item/{id:int}")]
    public async Task<IActionResult> DeleteItem(int id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteItemCommand(id), cancellationToken);
        return Ok("item deleted");
    }
    [HttpGet("get-concrete-order-items/{id:int}")]
    public async Task<IActionResult> GetItems(int id, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetByIdItemsQuery(id), cancellationToken);
        return Ok(response);
    }
}