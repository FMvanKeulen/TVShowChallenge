using TVShowTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TVShowTracker.Infra.Data.EntityConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasData(
                new Genre(1, "Drama"),
                new Genre(2, "Comedy"),
                new Genre(3, "Horror"),
                new Genre(4, "Science fiction"),
                new Genre(5, "Documentary"),
                new Genre(6, "Action"));
        }
    }
}