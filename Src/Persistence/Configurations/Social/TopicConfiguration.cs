namespace Persistence.Configurations.Social
{
    using Domain.Entities.Social;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Category)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(t => t.Content)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
