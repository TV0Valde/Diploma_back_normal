

using Application.CQRS.DTO.BuildingInfo;
using Application.Interfaces.Repositories;
using Domain.Enitities;
using Mapster;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.BuildingInfo;

public class UpdateBuildingInfoCommand : IRequest<BuildingInfoDto?>
{
	/// <summary>
	/// Id информационного блока
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }

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

	public UpdateBuildingInfoCommand(int id,string projectDesignation, string projectName, string stage, string areaAdress, int buildingId)
	{
		Id = id;
		ProjectDesignation = projectDesignation;
		ProjectName = projectName;
		Stage = stage;
		AreaAdress = areaAdress;
		BuildingId = buildingId;
	}

	public class UpdateBuildingInfoCommandHandler : IRequestHandler<UpdateBuildingInfoCommand, BuildingInfoDto?>
	{
		private readonly IBuildingInfoRepository _repository;

		public UpdateBuildingInfoCommandHandler(IBuildingInfoRepository repository)
		{
			_repository = repository;
		}

		public async Task<BuildingInfoDto?> Handle(UpdateBuildingInfoCommand command, CancellationToken cancellationToken)
		{
			var info = new BuildingInfoEntity
			{	Id = command.Id,
				ProjectDesignation = command.ProjectDesignation,
				ProjectName = command.ProjectName,
				Stage = command.Stage,
				AreaAdress = command.AreaAdress,
				BuildingId = command.BuildingId
			};

			await _repository.UpdateBuildingInfoAsync(info);
			return info.Adapt<BuildingInfoDto>();
		}
	
	}

}
