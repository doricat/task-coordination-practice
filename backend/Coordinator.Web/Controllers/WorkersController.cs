using Microsoft.AspNetCore.Mvc;

namespace Coordinator.Web.Controllers;

[ApiController]
[Route("api/workers")]
public class WorkersController : ControllerBase
{
    private readonly ILogger<WorkersController> _logger;

    public WorkersController(ILogger<WorkersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Task<IActionResult> Gets()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:maxlength(20)}")]
    public Task<IActionResult> Get([FromRoute] string id)
    {
        throw new NotImplementedException();
    }
}