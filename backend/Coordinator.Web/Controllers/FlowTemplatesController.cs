using Microsoft.AspNetCore.Mvc;

namespace Coordinator.Web.Controllers;

[ApiController]
[Route("api/flow-templates")]
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

    [HttpGet("{id:maxlength(20)}")]
    public Task<IActionResult> Get([FromRoute] string id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> Post([FromBody] object model)
    {
        throw new NotImplementedException();
    }
}