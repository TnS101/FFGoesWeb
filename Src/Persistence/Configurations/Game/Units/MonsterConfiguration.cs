namespace Persistence.Configurations.Game.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(m => m.Type)
                .HasDefaultValue("Monster")
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.ImagePath)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
