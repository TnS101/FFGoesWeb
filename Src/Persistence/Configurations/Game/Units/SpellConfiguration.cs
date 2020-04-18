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

            builder.Property(s => s.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.Type)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.BuffOrEffectTarget)
                .HasMaxLength(20);

            builder.Property(s => s.AdditionalEffect)
                .HasMaxLength(50);

            builder.Property(s => s.ClassType)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
