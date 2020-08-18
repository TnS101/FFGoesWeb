namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConsumeableInventoryConfiguration : IEntityTypeConfiguration<ConsumeableInventory>
    {
        public void Configure(EntityTypeBuilder<ConsumeableInventory> builder)
        {
            builder.HasKey(k => new { k.ConsumeableId, k.HeroId });

            builder.Property(ci => ci.HeroId).HasColumnType("bigint");

            builder.HasOne(c => c.Consumeable)
                .WithMany(ci => ci.ConsumeableInventories)
                .HasForeignKey(c => c.ConsumeableId);

            builder.HasOne(i => i.Hero)
                .WithMany(ci => ci.ConsumeableInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
