using TVShowTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TVShowTracker.Infra.Data.EntityConfiguration
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasMany(s => s.Actors).WithMany(a => a.Shows);
            builder.HasMany(s => s.Genres);
            builder.HasMany(s => s.Episodes);

            builder.HasData(
                new Show(1, "Vikings"),
                new Show(2, "Raised by Wolves"),
                new Show(3, "Breaking Bad"),
                new Show(4, "Better Call Saul"),
                new Show(5, "24: Redemption"),
                new Show(6, "Designated Survivor"));
        }
    }
}