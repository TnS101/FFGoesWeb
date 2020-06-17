namespace Persistence.Configurations.Game.Items.ManyToMany.Equipments
{
    using Domain.Entities.Game.Items.ManyToMany.Equipments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CardEquipmentConfiguration : IEntityTypeConfiguration<CardEquipment>
    {
        public void Configure(EntityTypeBuilder<CardEquipment> builder)
        {
            builder.HasKey(ce => new { ce.CardId, ce.EquipmentId });

            builder.Property(ce => ce.CardId).HasColumnType("bigint");

            builder.Property(ce => ce.EquipmentId).HasColumnType("bigint");

            builder.HasOne(c => c.Card)
                .WithMany(ce => ce.CardEquipment)
                .HasForeignKey(c => c.CardId);

            builder.HasOne(e => e.Equipment)
                .WithMany(ce => ce.CardEquipment)
                .HasForeignKey(e => e.EquipmentId);
        }
    }
}
