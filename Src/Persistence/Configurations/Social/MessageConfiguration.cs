namespace Persistence.Configurations.Social
{
    using Domain.Entities.Social;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.UserId)
                .IsRequired();

            builder.Property(m => m.Content)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.SenderName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
