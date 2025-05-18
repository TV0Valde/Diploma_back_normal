
using Domain.Enitities;

namespace Domain.Entities;

public class PointRecordsEntity
{
    public int Id { get; set; }
    public int PointId { get; set; }
    public Guid? PhotoId { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Info { get; set; }
    public string? MaterialName { get; set; }
    public DateOnly? CheckupDate { get; set; }
    public Points? Point { get; set; } 

    public PointPhoto? Photo { get; set; }
}
