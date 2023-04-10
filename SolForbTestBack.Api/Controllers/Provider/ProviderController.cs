using Application.Commands.Provider.CreateProvider;
using Application.Queries.OrderActions.GetAllOrders;
using Application.Queries.ProviderAction.GetAllProviders;
using Microsoft.AspNetCore.Mvc;

namespace SolForbTestBack.Controllers.Provider;

[ApiController]
[Route("api/provider")]
public class ProviderController : BaseController
{
    [HttpPost("create-provider")]
    public async Task<IActionResult> SaveOrder([FromBody] CreateProviderCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Ok("provider added");
    }
    [HttpGet("get-all-provider")]
    public async Task<IActionResult> GetAllProvider(CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new GetAllProvidersQuery(), cancellationToken);
        return Ok(response);
    }
}