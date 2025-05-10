using Domain.Enitities;

namespace Domain.Entities
{
    public class Building
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool Selected { get; set; }

        public IEnumerable<Points> Points { get; set; }

        public BuildingInfoEntity? BuildingInfo { get; set; }
    }
}
