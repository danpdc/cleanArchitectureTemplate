using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Physicube.Application.Activities;
using Physicube.Application.Activities.Cycling;
using Physicube.Application.Activities.Running;
using Physicube.Application.Activities.Walking;

namespace Physiqube.API.Activities;

[Authorize]
[ApiController]
[Route("api/activities")]
public class ActivitiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ShowActivityLog([FromQuery] GetActivityLog request, 
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("walking")]
    public async Task<IActionResult> LogWalkingActivity([FromBody] LogWalkingActivity newActivity, 
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(newActivity, cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    [Route("walking")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetWalkingActivities());
        return Ok(result);
    }
    
    [HttpPost]
    [Route("running")]
    public async Task<IActionResult> LogRunningActivity([FromBody] LogRunningActivity newActivity, 
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(newActivity, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("running")]
    public async Task<IActionResult> GetRuns()
    {
        var result = await mediator.Send(new GetRunningActivities());
        return Ok(result);
    }
    
    [HttpPost]
    [Route("cycling")]
    public async Task<IActionResult> LogCyclingActivity([FromBody] LogCyclingActivity newActivity, 
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(newActivity, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("cycling")]
    public async Task<IActionResult> GetCyclingActivities()
    {
        var result = await mediator.Send(new GetRides());
        return Ok(result);
    }
}