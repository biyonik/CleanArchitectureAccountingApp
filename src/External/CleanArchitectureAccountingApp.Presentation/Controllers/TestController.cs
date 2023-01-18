using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public sealed class TestController: BaseApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Success!");
    }
}