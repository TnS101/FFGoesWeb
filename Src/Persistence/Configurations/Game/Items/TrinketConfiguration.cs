namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrinketConfiguration : IEntityTypeConfiguration<Trinket>
    {
        public void Configure(EntityTypeBuilder<Trinket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnType("bigint");

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Slot)
                .HasDefaultValue("Trinket");

            builder.Property(t => t.ClassType)
                .HasDefaultValue("Any");

            builder.Property(t => t.Effect)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.MaterialType)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
