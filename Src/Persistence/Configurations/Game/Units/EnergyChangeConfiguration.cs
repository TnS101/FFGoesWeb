namespace Persistence.Configurations.Game.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EnergyChangeConfiguration : IEntityTypeConfiguration<EnergyChange>
    {
        public void Configure(EntityTypeBuilder<EnergyChange> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.HeroId)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
