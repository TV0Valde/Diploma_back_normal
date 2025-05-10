
namespace Domain.Entities;

public class PointRecordsEntity
{
    public int Id { get; set; }
    public int PointId { get; set; }
    public string? PhotoData { get; set; }
    public string? Info { get; set; }
    public string? MaterialName { get; set; }
    public DateOnly? CheckupDate { get; set; }
    public Points? Points { get; set; } 
}
