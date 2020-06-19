namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootKeyConfiguration : IEntityTypeConfiguration<LootKey>
    {
        public void Configure(EntityTypeBuilder<LootKey> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Type)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Slot)
                .HasDefaultValue("Treasure Key");

            builder.Property(t => t.ImagePath)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
