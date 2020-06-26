namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootBoxConfiguration : IEntityTypeConfiguration<LootBox>
    {
        public void Configure(EntityTypeBuilder<LootBox> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Type)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Slot)
                .HasDefaultValue("Loot Box");

            builder.Property(t => t.ImagePath)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
