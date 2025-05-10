using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.CQRS.Command.Format;
using Application.CQRS.DTO.Format;


namespace WebApi.Controllers;

[Route("api")]
[ApiController]
public class FormatController : ControllerBase
{
    private readonly IMediator _mediator;

    public FormatController(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Получение всех форматов области видимости.
    /// </summary>
    /// <returns>Форматы области видимости.</returns>
    [HttpGet("format")]
    public async Task<ActionResult<IEnumerable<FormatDto?>>> GetFormats()
    {
        var result = await _mediator.Send(new FormatCommand());
        return Ok(result);
    }
}
