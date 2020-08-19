namespace Persistence.Configurations.Game.Units.ManyToMany
{
    using Domain.Entities.Game.Units.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HeroTalentsConfiguration : IEntityTypeConfiguration<HeroTalents>
    {
        public void Configure(EntityTypeBuilder<HeroTalents> builder)
        {
            builder.HasKey(k => new { k.HeroId, k.TalentId });

            builder.Property(h => h.HeroId).HasColumnType("bigint");

            builder.HasOne(h => h.Hero)
                .WithMany(ht => ht.HeroTalents)
                .HasForeignKey(h => h.HeroId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Talent)
                .WithMany(ht => ht.HeroTalents)
                .HasForeignKey(t => t.TalentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
