namespace Persistence.Configurations.Social
{
    using Domain.Entities.Social;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.UserId)
                .IsRequired();

            builder.Property(n => n.Type)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(n => n.ApplicationSection)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(n => n.Content)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
