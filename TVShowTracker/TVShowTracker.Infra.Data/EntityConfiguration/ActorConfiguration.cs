using TVShowTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TVShowTracker.Infra.Data.EntityConfiguration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.HasOscar).IsRequired();
            builder.HasMany(x => x.Shows).WithMany(s => s.Actors);

            builder.HasData(
                new Actor(1, "Travis Fimmel", 42, "Australian", false),
                new Actor(2, "Katheryn Winnick", 44, "Canadian", false),
                new Actor(3, "Giancarlo Esposito", 64, "American", false),
                new Actor(4, "Bryan Cranston", 66, "American", false),
                new Actor(5, "Kiefer Sutherland", 55, "English", false));
        }
    }
}