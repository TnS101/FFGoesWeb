namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArmorConfiguration : IEntityTypeConfiguration<Armor>
    {
        public void Configure(EntityTypeBuilder<Armor> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Slot)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.ClassType)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Type)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
