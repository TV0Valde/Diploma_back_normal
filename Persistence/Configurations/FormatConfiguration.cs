using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enitities;

namespace Domain.EntityTypeConfiguration
{
    public class FormatCongfiguration : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}