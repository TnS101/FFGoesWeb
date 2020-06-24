namespace Persistence.Configurations.Game.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Type)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.ImagePath)
                .HasMaxLength(100)
                .IsRequired();

            builder.Ignore(m => m.CurrentArmorValue);
            builder.Ignore(m => m.CurrentAttackPower);
            builder.Ignore(m => m.CurrentCritChance);
            builder.Ignore(m => m.CurrentHealthRegen);
            builder.Ignore(m => m.CurrentHP);
            builder.Ignore(m => m.CurrentMagicPower);
            builder.Ignore(m => m.CurrentMana);
            builder.Ignore(m => m.CurrentManaRegen);
            builder.Ignore(m => m.CurrentResistanceValue);

            builder.Ignore(m => m.BlindDuration);
            builder.Ignore(m => m.ConfusionDuration);
            builder.Ignore(m => m.ProvokeDuration);
            builder.Ignore(m => m.SilenceDuration);
            builder.Ignore(m => m.StunDuration);
            builder.Ignore(m => m.CoinAmount);
            builder.Ignore(m => m.MonsterRarityId);
        }
    }
}
