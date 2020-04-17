namespace Persistence.Configurations.Common
{
    using Domain.Entities.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.AllowedHeroes)
                .HasDefaultValue(4);

            builder.ToTable("Users");
        }
    }
}
