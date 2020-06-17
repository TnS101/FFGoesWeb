namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ToyConfiguration : IEntityTypeConfiguration<Toy>
    {
        public void Configure(EntityTypeBuilder<Toy> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Slot)
                .HasDefaultValue("Toy")
                .IsRequired();
        }
    }
}
