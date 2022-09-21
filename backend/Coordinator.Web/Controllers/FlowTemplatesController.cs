using Microsoft.AspNetCore.Mvc;

namespace Coordinator.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlowTemplatesController : ControllerBase
{
    private readonly ILogger<FlowTemplatesController> _logger;

    public FlowTemplatesController(ILogger<FlowTemplatesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Task<IActionResult> Gets()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public Task<IActionResult> Get([FromRoute] string id)
    {
        throw new NotImplementedException();
    }
}