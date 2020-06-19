﻿namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LootKeyConfiguration : IEntityTypeConfiguration<LootKey>
    {
        public void Configure(EntityTypeBuilder<LootKey> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Rarity)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Slot)
                .HasDefaultValue("Treasure Key");

            builder.Property(t => t.ImagePath)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}