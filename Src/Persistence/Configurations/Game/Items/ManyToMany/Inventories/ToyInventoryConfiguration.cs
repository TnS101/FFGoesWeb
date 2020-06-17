namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ToyInventoryConfiguration : IEntityTypeConfiguration<ToyInventory>
    {
        public void Configure(EntityTypeBuilder<ToyInventory> builder)
        {
            builder.HasKey(ti => new { ti.ToyId, ti.InventoryId });

            builder.Property(ti => ti.InventoryId).HasColumnType("bigint");

            builder.HasOne(t => t.Toy)
                .WithMany(ti => ti.ToyInventories)
                .HasForeignKey(a => a.ToyId);

            builder.HasOne(i => i.Inventory)
                .WithMany(ti => ti.ToyInventories)
                .HasForeignKey(i => i.InventoryId);

            builder.Property(i => i.Count)
                .HasDefaultValue(1);
        }
    }
}
