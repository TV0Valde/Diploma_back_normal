using Domain.Entities;

namespace Domain.Enitities
{
	public class BuildingInfoEntity
	{
		public int Id { get; set; }

		public string? ProjectDesignation { get; set; }

		public string? ProjectName { get; set; }

		public string? Stage { get; set; }

		public string? AreaAdress { get; set; }

		public int BuildingId { get; set; }


		public Building? Building { get; set; }
	}
}
