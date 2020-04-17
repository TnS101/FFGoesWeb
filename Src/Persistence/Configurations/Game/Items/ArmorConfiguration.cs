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
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.Slot)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.ClassType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.ImagePath)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.Type)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
