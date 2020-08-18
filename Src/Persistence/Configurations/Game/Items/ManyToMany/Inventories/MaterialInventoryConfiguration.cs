namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MaterialInventoryConfiguration : IEntityTypeConfiguration<MaterialInventory>
    {
        public void Configure(EntityTypeBuilder<MaterialInventory> builder)
        {
            builder.HasKey(mi => new { mi.MaterialId, mi.HeroId });

            builder.Property(mi => mi.HeroId).HasColumnType("bigint");

            builder.HasOne(m => m.Material)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(m => m.MaterialId);

            builder.HasOne(i => i.Hero)
                .WithMany(mi => mi.MaterialInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
