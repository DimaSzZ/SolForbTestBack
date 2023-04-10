using Application.Queries.Filters.DefaultFilter;
using Microsoft.AspNetCore.Mvc;

namespace SolForbTestBack.Controllers.Search;

[ApiController]
[Route("api/search")]
public class SearchController : BaseController
{
    [HttpPost("basic-sorting")]
    public async Task<IActionResult> SortOrders([FromBody] FilterQuery query, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}