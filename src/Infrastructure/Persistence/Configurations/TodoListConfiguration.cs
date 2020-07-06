
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(t => t.Body)
                .HasMaxLength(2000)
                .IsRequired();
            
            builder.Property(t => t.Header)
                .HasMaxLength(2000)
                .IsRequired();
        }
    }
}
