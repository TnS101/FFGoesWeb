namespace Persistence.Configurations.Game.Units.OneToOne
{
    using Domain.Entities.Game.Units.OneToOne;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MonsterRarityConfiguration : IEntityTypeConfiguration<MonsterRarity>
    {
        public void Configure(EntityTypeBuilder<MonsterRarity> builder)
        {
            builder.HasOne(m => m.Monster)
           .WithOne(mr => mr.MonsterRarity)
           .HasForeignKey<MonsterRarity>(mr => mr.MonsterId);
        }
    }
}
