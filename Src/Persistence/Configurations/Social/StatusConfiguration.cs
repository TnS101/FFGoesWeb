namespace Persistence.Configurations.Social
{
    using Domain.Entities.Social;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.IClass)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.DisplayName)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
