namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TreasureKeyInventoryConfiguration : IEntityTypeConfiguration<TreasureKeyInventory>
    {
        public void Configure(EntityTypeBuilder<TreasureKeyInventory> builder)
        {
            builder.HasKey(ti => new { ti.TreasureKeyId, ti.InventoryId });

            builder.HasOne(t => t.TreasureKey)
                .WithMany(ti => ti.TreasureKeyInventories)
                .HasForeignKey(t => t.TreasureKeyId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ti => ti.TreasureKeyInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
