using Microsoft.AspNetCore.Mvc;

namespace Worker.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public Task<IActionResult> Post([FromBody] object model)
    {
        throw new NotImplementedException();
    }
}