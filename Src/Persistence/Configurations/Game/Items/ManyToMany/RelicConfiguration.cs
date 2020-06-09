namespace Persistence.Configurations.Game.Items.ManyToMany
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RelicConfiguration : IEntityTypeConfiguration<Relic>
    {
        public void Configure(EntityTypeBuilder<Relic> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnType("bigint");

            builder.Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.Slot)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(r => r.ClassType)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(r => r.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(r => r.MaterialType)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
