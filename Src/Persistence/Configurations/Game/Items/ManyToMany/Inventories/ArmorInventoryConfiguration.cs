namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArmorInventoryConfiguration : IEntityTypeConfiguration<ArmorInventory>
    {
        public void Configure(EntityTypeBuilder<ArmorInventory> builder)
        {
            builder.HasKey(ai => new { ai.ArmorId, ai.InventoryId });

            builder.HasOne(a => a.Armor)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(a => a.ArmorId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ai => ai.ArmorInventories)
                .HasForeignKey(i => i.InventoryId);
        }
    }
}
