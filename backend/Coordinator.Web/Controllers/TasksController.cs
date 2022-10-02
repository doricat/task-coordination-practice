using Microsoft.AspNetCore.Mvc;

namespace Coordinator.Web.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
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

    [HttpPatch("{id:maxlength(20)}/pause")]
    public Task<IActionResult> Pause([FromRoute] string id, [FromBody] object model)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:maxlength(20)}/continue")]
    public Task<IActionResult> Continue([FromRoute] string id, [FromBody] object model)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:maxlength(20)}/abort")]
    public Task<IActionResult> Abort([FromRoute] string id)
    {
        throw new NotImplementedException();
    }
}