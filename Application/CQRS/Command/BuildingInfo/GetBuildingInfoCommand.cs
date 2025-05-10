

using Application.CQRS.DTO.BuildingInfo;
using Application.Interfaces.Services;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.BuildingInfo;

public sealed class GetBuildingInfoCommand : IRequest<BuildingInfoDto>
{
	/// <summary>
	/// id информационного блока.
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; }

	public GetBuildingInfoCommand(int id)
	{
		Id = id;
	}
}

public class Handler : IRequestHandler<GetBuildingInfoCommand, BuildingInfoDto>
{
	private readonly IBuildingInfoService _buildingInfoService;

	public Handler(IBuildingInfoService buildingInfoService)
	{
		_buildingInfoService = buildingInfoService;
	}

	public async Task<BuildingInfoDto?> Handle(GetBuildingInfoCommand command, CancellationToken cancellationToken)
	{
		var info = await _buildingInfoService.GetBuildingInfoByIdAsync(command.Id);
		return BuildingInfoDto.CreateFrom(info);
	}
}
