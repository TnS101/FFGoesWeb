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
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Rarity)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Slot)
                .HasDefaultValue("Treasure");

            builder.Property(t => t.ImagePath)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
