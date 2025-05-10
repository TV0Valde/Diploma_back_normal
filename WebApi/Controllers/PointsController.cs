using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CQRS.DTO.Points;
using Application.CQRS.Command.Point;

namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class PointsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PointsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("points")]
    public async Task<ActionResult<IEnumerable<PointsResultDto>>> GetAllPoints()
    {
        var result = await _mediator.Send(new PointCommand());
        return Ok(result);
    }

    [HttpGet("point/{id}")]
    public async Task<ActionResult<PointsResultDto?>> GetPointById(int id)
    {
        var result = await _mediator.Send(new PointGetCommand(id));
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("points/byBuilding/{buildingId}")]
    public async Task<ActionResult<List<PointsResultDto>>> GetPointsByBuildingId(int buildingId)
    {
        var query = new GetPointsByBuildingIdQuery(buildingId);
        var points = await _mediator.Send(query);
        return Ok(points);
    }


    [HttpPost("point")]
    public async Task<ActionResult<PointsResultDto?>> CreatePoint(PointAddCommand command)
    {
        var result = await _mediator.Send(command);
        if (result is null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetPointById), new { id = result.Id }, result);
    }

    [HttpPut("point/{id}")]
    public async Task<IActionResult> UpdatePoint(int id, PointUpdateCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(command);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("point/{id}")]
    public async Task<IActionResult> DeletePoint(int id)
    {
        await _mediator.Send(new PointDeleteCommand(id));
        return NoContent();
    }
}
