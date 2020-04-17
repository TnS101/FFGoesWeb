namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConsumeableInventoryConfiguration : IEntityTypeConfiguration<ConsumeableInventory>
    {
        public void Configure(EntityTypeBuilder<ConsumeableInventory> builder)
        {
            builder.HasKey(k => new { k.ConsumeableId, k.InventoryId });

            builder.HasOne(c => c.Consumeable)
                .WithMany(ci => ci.ConsumeableInventories)
                .HasForeignKey(c => c.ConsumeableId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ci => ci.ConsumeableInventories)
                .HasForeignKey(i => i.InventoryId);
        }
    }
}
