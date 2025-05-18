using Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PointPhotoConfiguration : IEntityTypeConfiguration<PointPhoto>
{
    public void Configure(EntityTypeBuilder<PointPhoto> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(pp => pp.PointRecord)
            .WithOne(pr => pr.Photo)
            .HasForeignKey<PointPhoto>(p => p.PointRecordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}