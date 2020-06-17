namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnType("bigint");

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Slot)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.ClassType)
                .HasDefaultValue("Any")
                .IsRequired();

            builder.Property(c => c.Effect)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.MaterialType)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
