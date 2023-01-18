using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Abstraction;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public abstract class BaseApiController: ControllerBase
{
    
}