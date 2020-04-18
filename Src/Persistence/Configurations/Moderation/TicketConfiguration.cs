namespace Persistence.Configurations.Moderation
{
    using Domain.Entities.Moderation;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.ReportedUserId)
                .IsRequired();

            builder.Property(t => t.Category)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Type)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(t => t.Content)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.AdditionalInformation)
                .HasMaxLength(60);
        }
    }
}
