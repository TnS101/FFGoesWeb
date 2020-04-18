namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TreasureKeyConfiguration : IEntityTypeConfiguration<TreasureKey>
    {
        public void Configure(EntityTypeBuilder<TreasureKey> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(t => t.Rarity)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.ImagePath)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
