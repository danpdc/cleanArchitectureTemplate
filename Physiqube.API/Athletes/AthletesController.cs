using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physicube.Application.Athletes;
using Physiqube.Common.Types;
using Physiqube.Domain.Athletes;

namespace Physiqube.API.Athletes;

[ApiController]
[Route("api/profile")]
[Authorize]
public class AthletesController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> DisplayAthleteProfile()
    {
        var result = await mediator.Send(new DisplayAthleteProfile());
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateBasicInformation(ChangeAthleteBasicInfo info)
    {
        var result = await mediator.Send(info);
        if (result is null)
            return BadRequest();
        return Ok(result);
    }
    
    [HttpPatch]
    [Route("location")]
    public async Task<IActionResult> UpdateLocation(Location location)
    {
        var command = new ChangeAthleteLocation(location);
        var result = await mediator.Send(command);
        if (result is null)
            return BadRequest();
        return Ok(result);
    }
    
    [HttpPatch]
    [Route("bodyInfo")]
    public async Task<IActionResult> UpdateBodyInfo(ChangeAthleteBodyInfo bodyInfo)
    {
        var result = await mediator.Send(bodyInfo);
        if (result is null)
            return BadRequest();
        return Ok(result);
    }
}

