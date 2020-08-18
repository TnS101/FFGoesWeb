namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrinketInventoryConfiguration : IEntityTypeConfiguration<TrinketInventory>
    {
        public void Configure(EntityTypeBuilder<TrinketInventory> builder)
        {
            builder.HasKey(ti => new { ti.TrinketId, ti.HeroId });

            builder.Property(ti => ti.TrinketId).HasColumnType("bigint");

            builder.Property(ti => ti.HeroId).HasColumnType("bigint");

            builder.HasOne(t => t.Trinket)
                .WithMany(ti => ti.TrinketInventories)
                .HasForeignKey(t => t.TrinketId);

            builder.HasOne(i => i.Hero)
                .WithMany(ti => ti.TrinketInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
