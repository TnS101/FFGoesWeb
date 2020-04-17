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
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(c => c.Type)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.ImagePath)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
