namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConsumeableConfiguration : IEntityTypeConfiguration<Consumeable>
    {
        public void Configure(EntityTypeBuilder<Consumeable> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Type)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Slot)
                .HasDefaultValue("Consumeable");

            builder.Property(c => c.ImagePath)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
