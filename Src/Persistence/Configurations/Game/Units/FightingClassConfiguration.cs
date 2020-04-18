namespace Persistence.Configurations.Game.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FightingClassConfiguration : IEntityTypeConfiguration<FightingClass>
    {
        public void Configure(EntityTypeBuilder<FightingClass> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.ClassType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(f => f.IconPath)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.ImagePath)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
