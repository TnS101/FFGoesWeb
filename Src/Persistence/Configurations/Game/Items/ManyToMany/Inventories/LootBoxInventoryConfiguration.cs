namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootBoxInventoryConfiguration : IEntityTypeConfiguration<LootBoxInventory>
    {
        public void Configure(EntityTypeBuilder<LootBoxInventory> builder)
        {
            builder.HasKey(ti => new { ti.LootBoxId, ti.InventoryId });

            builder.Property(ti => ti.InventoryId).HasColumnType("bigint");

            builder.HasOne(t => t.LootBox)
                .WithMany(ti => ti.LootBoxInventories)
                .HasForeignKey(t => t.LootBoxId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ti => ti.LootBoxInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
