namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MaterialInventoryConfiguration : IEntityTypeConfiguration<MaterialInventory>
    {
        public void Configure(EntityTypeBuilder<MaterialInventory> builder)
        {
            builder.HasKey(mi => new { mi.MaterialId, mi.InventoryId });

            builder.Property(mi => mi.InventoryId).HasColumnType("bigint");

            builder.HasOne(m => m.Material)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(m => m.MaterialId);

            builder.HasOne(i => i.Inventory)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
