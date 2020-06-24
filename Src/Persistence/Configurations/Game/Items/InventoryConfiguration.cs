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

            builder.Property(i => i.Id).HasColumnType("bigint").ValueGeneratedOnAdd();

            builder.Property(i => i.Capacity)
                .HasDefaultValue(100);
        }
    }
}
