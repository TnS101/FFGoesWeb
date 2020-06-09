namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RelicInventoryConfiguration : IEntityTypeConfiguration<RelicInventory>
    {
        public void Configure(EntityTypeBuilder<RelicInventory> builder)
        {
            builder.HasKey(ri => new { ri.RelicId, ri.InventoryId });

            builder.Property(ri => ri.RelicId).HasColumnType("bigint");

            builder.Property(ri => ri.InventoryId).HasColumnType("bigint");

            builder.HasOne(r => r.Relic)
                .WithMany(r => r.RelicInventories)
                .HasForeignKey(r => r.RelicId);

            builder.HasOne(i => i.Inventory)
                .WithMany(r => r.RelicInventories)
                .HasForeignKey(i => i.InventoryId);
        }
    }
}
