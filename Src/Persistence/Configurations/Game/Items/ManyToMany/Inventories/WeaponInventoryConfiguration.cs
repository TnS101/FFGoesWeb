namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WeaponInventoryConfiguration : IEntityTypeConfiguration<WeaponInventory>
    {
        public void Configure(EntityTypeBuilder<WeaponInventory> builder)
        {
            builder.HasKey(wi => new { wi.WeaponId, wi.HeroId });

            builder.Property(wi => wi.WeaponId).HasColumnType("bigint");

            builder.Property(wi => wi.HeroId).HasColumnType("bigint");

            builder.HasOne(w => w.Weapon)
                .WithMany(w => w.WeaponInventories)
                .HasForeignKey(w => w.WeaponId);

            builder.HasOne(i => i.Hero)
                .WithMany(wi => wi.WeaponInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
               .HasDefaultValue(1);
        }
    }
}
