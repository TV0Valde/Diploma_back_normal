
namespace Domain.Entities
{
    public class Points
    {
        public int Id { get; set; }

        public int BuildingId { get; set; }

        public float[]? Position { get; set; }

        public Building? Building { get; set; }

       public ICollection<PointRecordsEntity> Records { get; set; } = new List<PointRecordsEntity>();
    }
}
