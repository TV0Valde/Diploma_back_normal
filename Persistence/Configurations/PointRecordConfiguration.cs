using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Domain.EntityTypeConfiguration
{
    public class PointRecordConfiguration : IEntityTypeConfiguration<PointRecordsEntity>
    {
        public void Configure(EntityTypeBuilder<PointRecordsEntity> builder)
        {
           
            builder.HasKey(pr => pr.Id);
  
            builder
                .HasOne(pr => pr.Point)
                .WithMany(p => p.Records)
                .HasForeignKey(pr => pr.PointId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder
                .Property(pr => pr.CheckupDate)
                .HasColumnType("date");
        }
    }
}
