using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureAccountingApp.Presentation.Abstraction;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public abstract class BaseApiController: ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => (_mediator ??= HttpContext.RequestServices.GetService<IMediator>())!;
}