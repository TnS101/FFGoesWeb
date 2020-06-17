namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CardInventories : IEntityTypeConfiguration<CardInventory>
    {
        public void Configure(EntityTypeBuilder<CardInventory> builder)
        {
            builder.HasKey(ci => new { ci.CardId, ci.InventoryId });

            builder.Property(ci => ci.CardId).HasColumnType("bigint");

            builder.Property(ci => ci.InventoryId).HasColumnType("bigint");

            builder.HasOne(c => c.Card)
                .WithMany(ci => ci.CardInventories)
                .HasForeignKey(c => c.CardId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ci => ci.CardInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
                .HasDefaultValue(1);
        }
    }
}
