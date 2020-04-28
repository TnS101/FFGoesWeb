namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Slot)
                .HasDefaultValue("Material");

            builder.Property(m => m.ImagePath)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
