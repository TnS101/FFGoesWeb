namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.Property(i => i.HeroId)
                .IsRequired();

            builder.Property(i => i.Capacity)
                .HasDefaultValue(50);

            builder.HasOne(u => u.Hero)
           .WithOne(i => i.Inventory)
           .HasForeignKey<Inventory>(u => u.HeroId);
        }
    }
}
