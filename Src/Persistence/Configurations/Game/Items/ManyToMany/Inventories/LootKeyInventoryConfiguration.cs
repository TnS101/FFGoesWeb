namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootKeyInventoryConfiguration : IEntityTypeConfiguration<LootKeyInventory>
    {
        public void Configure(EntityTypeBuilder<LootKeyInventory> builder)
        {
            builder.HasKey(ti => new { ti.LootKeyId, ti.HeroId });

            builder.Property(ti => ti.HeroId).HasColumnType("bigint");

            builder.HasOne(t => t.LootKey)
                .WithMany(ti => ti.LootKeyInventories)
                .HasForeignKey(t => t.LootKeyId);

            builder.HasOne(i => i.Hero)
                .WithMany(ti => ti.LootKeyInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
