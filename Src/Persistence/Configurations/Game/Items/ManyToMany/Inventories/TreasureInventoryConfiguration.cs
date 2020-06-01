namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TreasureInventoryConfiguration : IEntityTypeConfiguration<TreasureInventory>
    {
        public void Configure(EntityTypeBuilder<TreasureInventory> builder)
        {
            builder.HasKey(ti => new { ti.TreasureId, ti.InventoryId });

            builder.Property(ti => ti.InventoryId).HasColumnType("bigint");

            builder.HasOne(t => t.Treasure)
                .WithMany(ti => ti.TreasureInventories)
                .HasForeignKey(t => t.TreasureId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ti => ti.TreasureInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
