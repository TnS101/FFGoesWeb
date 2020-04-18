﻿namespace Persistence.Configurations.Game.Units.ManyToMany
{
    using Domain.Entities.Game.Units.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HeroSpellsConfiguration : IEntityTypeConfiguration<HeroSpells>
    {
        public void Configure(EntityTypeBuilder<HeroSpells> builder)
        {
            builder.HasKey(k => new { k.SpellId, k.HeroId });

            builder.HasOne(s => s.Spell)
                .WithMany(hs => hs.HeroSpells)
                .HasForeignKey(s => s.SpellId);

            builder.HasOne(h => h.Hero)
                .WithMany(hs => hs.HeroSpells)
                .HasForeignKey(h => h.HeroId);
        }
    }
}