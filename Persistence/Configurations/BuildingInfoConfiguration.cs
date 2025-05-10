using Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BuildingInfoConfiguration : IEntityTypeConfiguration<BuildingInfoEntity>
    {
        public void Configure(EntityTypeBuilder<BuildingInfoEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Building)
                .WithOne(y => y.BuildingInfo)
                .HasForeignKey<BuildingInfoEntity>(p => p.BuildingId);
        }
    }
}
