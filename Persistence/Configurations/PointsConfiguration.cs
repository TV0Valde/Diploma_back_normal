using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Domain.EntityTypeConfiguration
{
    public class PointsConfiguration : IEntityTypeConfiguration<Points>
    {
        public void Configure(EntityTypeBuilder<Points> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Building)
                .WithMany(b => b.Points)
                .HasForeignKey(p => p.BuildingId);
        }
    }

}
