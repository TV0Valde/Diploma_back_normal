using Application.CQRS.Command.BuildingInfo;
using Application.CQRS.DTO.BuildingInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/")]
[ApiController]
public class BuildingInfoController : ControllerBase
{
	private readonly IMediator _mediator;

	public BuildingInfoController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("buildingInfo/{id}")]
	public async Task<IActionResult> GetBuidingInfo(int id)
	{
		var result = await _mediator.Send(new GetBuildingInfoCommand(id));
		if (result == null)
		{
			return NotFound();
		}
		return Ok(result);
	}

	[HttpGet("buildingInfos")]
	public async Task<ActionResult<IEnumerable<BuildingInfoDto?>>> GetBuildingInfos()
	{
		var resut = await _mediator.Send(new BuildingInfoCommand());
		return Ok(resut);
	}

	[HttpGet("buildingInfo/byBuilding/{buildingId}")]
	public async Task<ActionResult<BuildingInfoDto>> GetBuildingInfoByBuildingId(int buildingId)
	{
		var requset = new GetBuildingInfoByBuildingCommand(buildingId);
		var info = await _mediator.Send(requset);
		if (info == null)
		{
			return NotFound();
		}
		return Ok(info);
	}

	[HttpPost("buildingInfo")]
	public async Task<IActionResult> CreateBuildingInfo(AddBuildingInfoCommand command)
	{
		var result = await _mediator.Send(command);
		if (result is null)
		{
			return BadRequest();
		}
		return CreatedAtAction(nameof(GetBuidingInfo), new { id = result.Id }, result);
	}

	[HttpPut("buildingInfo/{id}")]
	public async Task<IActionResult> UpdatePoint(int id, UpdateBuildingInfoCommand command)
	{
		if (id != command.Id)
		{
			return BadRequest();
		}

		var result = await _mediator.Send(command);
		if (result is null)
		{
			return NotFound();
		}

		return Ok(result);
	}

	[HttpDelete("buildingInfo/{id}")]
	public async Task<IActionResult> DeleteBuildingInfo(int id)
	{
		await _mediator.Send(new DeleteBuildingInfoCommand(id));
		return NoContent();
	}

}
