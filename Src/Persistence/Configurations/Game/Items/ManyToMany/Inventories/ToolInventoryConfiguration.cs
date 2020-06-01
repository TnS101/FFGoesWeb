namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ToolInventoryConfiguration : IEntityTypeConfiguration<ToolInventory>
    {
        public void Configure(EntityTypeBuilder<ToolInventory> builder)
        {
            builder.HasKey(k => new { k.ToolId, k.InventoryId });

            builder.Property(ti => ti.InventoryId).HasColumnType("bigint");

            builder.HasOne(t => t.Tool)
                .WithMany(ti => ti.ToolInventories)
                .HasForeignKey(t => t.ToolId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ti => ti.ToolInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
