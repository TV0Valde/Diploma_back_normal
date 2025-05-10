using Application.CQRS.DTO.Format;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using System.Diagnostics.Metrics;

namespace Application.CQRS.Command.Format;

public sealed class FormatCommand : IRequest<IEnumerable<FormatDto?>>
{
}

public class FormatCommandHandler : IRequestHandler<FormatCommand, IEnumerable<FormatDto>>
{
    private readonly IFormatService _service;

    public FormatCommandHandler(IFormatService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<FormatDto>> Handle(FormatCommand command, CancellationToken cancellationToken)
    {
        var formats = await _service.GetFormatsAsync();
        return formats;
    }
}