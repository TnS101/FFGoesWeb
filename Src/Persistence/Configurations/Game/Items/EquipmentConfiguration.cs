namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.HeroId)
                .IsRequired();

            builder.Property(e => e.Capacity)
                .HasDefaultValue(9);

            builder.HasOne(h => h.Hero)
           .WithOne(e => e.Equipment)
           .HasForeignKey<Equipment>(h => h.HeroId);
        }
    }
}
