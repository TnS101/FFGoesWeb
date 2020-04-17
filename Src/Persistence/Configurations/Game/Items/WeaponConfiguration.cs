﻿namespace Persistence.Configurations.Game.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(w => w.ClassType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(w => w.Slot)
                .HasDefaultValue("Weapon")
                .IsRequired();

            builder.Property(w => w.ImagePath)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(w => w.Type)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
