using Domain.Entities;

namespace Domain.Enitities;

public class PointPhoto
{
    public Guid Id { get; set; }
    public string ObjectName { get; set; }
    public string OriginalFileName { get; set; }
    public string ContentType { get; set; }
    public string BucketName { get; set; } = "cracks";
    public long Size { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public int? PointRecordId { get; set; }
    public PointRecordsEntity PointRecord { get; set; }
}