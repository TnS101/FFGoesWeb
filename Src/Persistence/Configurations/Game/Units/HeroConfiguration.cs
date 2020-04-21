namespace Persistence.Configurations.Game.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HeroConfiguration : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.EquipmentId)
                .IsRequired();

            builder.Property(h => h.UserId)
                .IsRequired();

            builder.Property(h => h.InventoryId)
                .IsRequired();

            builder.Property(h => h.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.ClassType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.Race)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(h => h.IconPath)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(h => h.ImagePath)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(h => h.Type)
                .HasDefaultValue("Player")
                .IsRequired();

            builder.Property(h => h.Level)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(h => h.XPCap)
                .HasDefaultValue(100)
                .IsRequired();

            builder.Property(h => h.GoldAmount)
                .HasDefaultValue(100)
                .IsRequired();

            builder.Property(h => h.Energy)
                .HasDefaultValue(30)
                .IsRequired();

            builder.Property(h => h.ProfessionEnergy)
                .HasDefaultValue(10)
                .IsRequired();

            builder.Property(h => h.PvPEnergy)
                .HasDefaultValue(15)
                .IsRequired();

            builder.Property(h => h.IsSelected)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
