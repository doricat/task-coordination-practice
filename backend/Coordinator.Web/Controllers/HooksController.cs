using Coordinator.Web.ApplicationServices;
using Coordinator.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Coordinator.Web.Controllers;

[ApiController]
[Route("api/hooks")]
public class HooksController : ControllerBase
{
    private readonly ILogger<HooksController> _logger;
    private readonly IWorkerRegistrationService _registrationService;

    public HooksController(ILogger<HooksController> logger, 
        IWorkerRegistrationService registrationService)
    {
        _logger = logger;
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OutsideWorkerRegistrationModel model)
    {
        var id = await _registrationService.Register(model);
        return Created(id, null);
    }

    [HttpDelete("{id:maxlength(20)}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _registrationService.Cancel(id);
        return NoContent();
    }
}