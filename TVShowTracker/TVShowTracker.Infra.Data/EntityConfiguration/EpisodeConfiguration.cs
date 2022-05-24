using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Infra.Data.EntityConfiguration
{
    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.ReleaseDate).IsRequired();
        }
    }
}