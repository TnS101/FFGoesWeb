namespace Persistence.Configurations.Social
{
    using Domain.Entities.Social;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId);

            builder.Property(c => c.TopicId)
                .IsRequired();

            builder.Property(c => c.Content)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(p => p.Replies)
            .WithOne(t => t.Reply)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
