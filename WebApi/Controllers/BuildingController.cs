using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CQRS.Command.Building;
using Application.CQRS.DTO.Building;


namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BuildingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("buiding/{id}")]
    public async Task<IActionResult> GetBuilding(int id)
    {
        var result = await _mediator.Send(new BuildingGetCommand(id));
        if (result == null) 
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("buiding/search")]
    public async Task<IActionResult> GetBuildingByName([FromQuery] string name)
    {
        var result = await _mediator.Send(new GetBuildingByNameCommand(name));
        return result == null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Получение всех зданий.
    /// </summary>
    /// <returns>Коллекция Зданий.</returns>
    [HttpGet("building")]
    public async Task<ActionResult<IEnumerable<BuildingResultDto?>>> GetBuildings()
    {
        var result = await _mediator.Send(new GetBuildingsCommand());
        return Ok(result);
    }
}
