namespace Persistence.Configurations.Game.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SpellConfiguration : IEntityTypeConfiguration<Spell>
    {
        public void Configure(EntityTypeBuilder<Spell> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Type)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.BuffOrEffectTarget)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(s => s.AdditionalEffect)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.ClassType)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
