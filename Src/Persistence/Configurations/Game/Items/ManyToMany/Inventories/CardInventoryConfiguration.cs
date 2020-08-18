namespace Persistence.Configurations.Game.Items.ManyToMany.Inventories
{
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CardInventoryConfiguration : IEntityTypeConfiguration<CardInventory>
    {
        public void Configure(EntityTypeBuilder<CardInventory> builder)
        {
            builder.HasKey(ci => new { ci.CardId, ci.HeroId });

            builder.Property(ci => ci.CardId).HasColumnType("bigint");

            builder.Property(ci => ci.HeroId).HasColumnType("bigint");

            builder.HasOne(c => c.Card)
                .WithMany(ci => ci.CardInventories)
                .HasForeignKey(c => c.CardId);

            builder.HasOne(i => i.Hero)
                .WithMany(ci => ci.CardInventories)
                .HasForeignKey(i => i.HeroId);

            builder.Property(i => i.Count)
                .HasDefaultValue(1);
        }
    }
}
