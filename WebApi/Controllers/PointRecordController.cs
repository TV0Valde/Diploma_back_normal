using Microsoft.AspNetCore.Mvc;
using Application.CQRS.DTO.Points;
using MediatR;
using Application.CQRS.Command.PointRecords;
using Application.CQRS.Command.PointRecord;

namespace WebApi.Controllers;

[ApiController]
[Route("api")]
public class PointRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PointRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("point/{pointId}/records")]
    public async Task<ActionResult<IEnumerable<PointRecordDto>>> GetRecordsByPointId(int pointId)
    {
        var records = await _mediator.Send(new PointRecordCommand(pointId));
        return Ok(records);
    }


    [HttpGet("pointRecord/{recordId}")]
    public async Task<IActionResult> GetRecordById(int recordId)
    {
        var record = await _mediator.Send(new GetPointRecordCommand(recordId));
        if (record == null)
        {
            return NotFound();
        }
        return Ok(record);
    }


    [HttpPost("point/{pointId}/records")]
    public async Task<IActionResult> CreateRecord(int pointId, [FromForm] AddPointRecordCommand command)
    {
        var createdRecord = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetRecordById), new { recordId = createdRecord?.Id }, createdRecord);
    }


    [HttpPut("pointRecord/{recordId}")]
    public async Task<IActionResult> UpdateRecord(int recordId, [FromForm] UpdatePointRecordCommand command)
    {
        command.RecordId = recordId;

        var result = await _mediator.Send(command);
        return Ok(result);
    }


    [HttpDelete("pointRecord/{recordId}")]
    public async Task<IActionResult> DeleteRecord(int recordId)
    {
        await _mediator.Send(new DeletePointRecordCommand(recordId));
        return NoContent();
    }
}

