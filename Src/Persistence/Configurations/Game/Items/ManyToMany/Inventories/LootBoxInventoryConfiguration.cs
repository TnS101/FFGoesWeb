namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootBoxInventoryConfiguration : IEntityTypeConfiguration<LootBoxInventory>
    {
        public void Configure(EntityTypeBuilder<LootBoxInventory> builder)
        {
            builder.HasKey(ti => new { ti.LootBoxId, ti.HeroId });

            builder.Property(ti => ti.HeroId).HasColumnType("bigint");

            builder.HasOne(t => t.LootBox)
                .WithMany(ti => ti.LootBoxInventories)
                .HasForeignKey(t => t.LootBoxId);

            builder.HasOne(i => i.Hero)
                .WithMany(ti => ti.LootBoxInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
