using Application.CQRS.DTO.BuildingInfo;
using Application.Interfaces.Repositories;
using Domain.Enitities;
using Mapster;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.BuildingInfo;

public class AddBuildingInfoCommand : IRequest<BuildingInfoDto?>
{
	/// <summary>
	/// Обозначение проекта
	/// </summary>
	[JsonPropertyName("projectDesignation")]
	public string? ProjectDesignation { get; set; }

	/// <summary>
	/// Имя проекта
	/// </summary>
	[JsonPropertyName("projectName")]
	public string? ProjectName { get; set; }

	/// <summary>
	/// Стадия
	/// </summary>
	[JsonPropertyName("stage")]
	public string? Stage { get; set; }

	/// <summary>
	/// Адрес участка
	/// </summary>
	[JsonPropertyName("areaAdress")]
	public string? AreaAdress { get; set; }

	/// <summary>
	/// Id здания
	/// </summary>
	[JsonPropertyName("buildingId")]
	public int BuildingId { get; set; }

	public AddBuildingInfoCommand(string projectDesignation, string projectName, string stage, string areaAdress, int buildingId)
	{
		ProjectDesignation = projectDesignation;
		ProjectName = projectName;
		Stage = stage;
		AreaAdress = areaAdress;
		BuildingId = buildingId;
	}

	public class AddBuildingInfoCommandHandler : IRequestHandler<AddBuildingInfoCommand,BuildingInfoDto?>
	{
		private readonly IBuildingInfoRepository _repository;

		public AddBuildingInfoCommandHandler(IBuildingInfoRepository repository)
		{
			_repository = repository;
		}

		public async Task<BuildingInfoDto?> Handle(AddBuildingInfoCommand command, CancellationToken cancellationToken)
		{
			var info = new BuildingInfoEntity
			{
				ProjectDesignation = command.ProjectDesignation,
				ProjectName = command.ProjectName,
				Stage = command.Stage,
				AreaAdress = command.AreaAdress,
				BuildingId = command.BuildingId
			};

			var createdInfo = await _repository.CreateBuildingInfoAsync(info);
			return createdInfo.Adapt<BuildingInfoDto>();
	}
	}
	
}
