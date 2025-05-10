

using Application.CQRS.Command.PointRecords;
using Application.Interfaces.Repositories;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.BuildingInfo;

public class DeleteBuildingInfoCommand : IRequest
{
	[JsonPropertyName("id")]
	public int BuildingInfoId { get; set; }

	public DeleteBuildingInfoCommand(int buildingInfoId)
	{
		BuildingInfoId = buildingInfoId;
	}
}

public class DeleteBuildingInfoCommandHandler : IRequestHandler<DeleteBuildingInfoCommand>
{
	private readonly IBuildingInfoRepository _repository;

	public DeleteBuildingInfoCommandHandler(IBuildingInfoRepository repository)
	{
		_repository = repository;
	}

	public async Task Handle(DeleteBuildingInfoCommand request, CancellationToken cancellationToken)
	{
		await _repository.DeleteBuildingInfoAsync(request.BuildingInfoId);
	}
}