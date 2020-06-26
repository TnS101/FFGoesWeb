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
                .HasDefaultValue("Card");

            builder.Property(c => c.ClassType)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Condition)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.MaterialType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Ignore(c => c.IsActivated);
            builder.Ignore(c => c.IsUsed);
        }
    }
}
