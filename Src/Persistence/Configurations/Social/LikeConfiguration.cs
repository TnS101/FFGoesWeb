namespace Persistence.Configurations.Social
{
    using Domain.Entities.Social;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.UserId)
                .IsRequired();
        }
    }
}
